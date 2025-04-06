using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FFMpegCore;
using FFMpegCore.Pipes;

namespace VideoMaker.Services
{
    public class FFmpegService
    {
        private readonly string _ffmpegPath;

        public FFmpegService()
        {
            // 在Windows上，我们将FFmpeg可执行文件放在应用程序目录下的ffmpeg文件夹中
            _ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
            GlobalFFOptions.Configure(options => options.BinaryFolder = _ffmpegPath);
        }

        // 剪切视频
        public async Task<bool> TrimVideoAsync(string inputFile, string outputFile, TimeSpan startTime, TimeSpan duration)
        {
            try
            {
                await FFMpegArguments
                    .FromFileInput(inputFile)
                    .OutputToFile(outputFile, false, options => options
                        .WithCustomArgument($"-ss {startTime}")
                        .WithDuration(duration)
                        .CopyChannel())
                    .ProcessAsynchronously();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"视频剪切失败: {ex.Message}");
                return false;
            }
        }

        // 合并视频
        public async Task<bool> ConcatVideosAsync(string[] inputFiles, string outputFile)
        {
            try
            {
                // 创建临时文件列表
                string tempFile = Path.GetTempFileName();
                using (StreamWriter sw = new StreamWriter(tempFile))
                {
                    foreach (var file in inputFiles)
                    {
                        sw.WriteLine($"file '{file.Replace("'", "\\'")}'");
                    }
                }

                // 使用FFmpeg的concat命令
                await FFMpegArguments
                    .FromFileInput(tempFile, false, options => options.WithCustomArgument("-f concat -safe 0"))
                    .OutputToFile(outputFile, false, options => options.WithCustomArgument("-c copy"))
                    .ProcessAsynchronously();

                // 删除临时文件
                File.Delete(tempFile);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"视频合并失败: {ex.Message}");
                return false;
            }
        }

        // 添加水印
        public async Task<bool> AddWatermarkAsync(string inputVideo, string watermarkImage, string outputVideo)
        {
            try
            {
                await FFMpegArguments
                    .FromFileInput(inputVideo)
                    .AddFileInput(watermarkImage)
                    .OutputToFile(outputVideo, false, options => options
                        .WithCustomArgument("-filter_complex \"[0:v][1:v] overlay=10:10\""))
                    .ProcessAsynchronously();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"添加水印失败: {ex.Message}");
                return false;
            }
        }

        // 调整视频速度
        public async Task<bool> ChangeVideoSpeedAsync(string inputFile, string outputFile, double speedFactor)
        {
            try
            {
                await FFMpegArguments
                    .FromFileInput(inputFile)
                    .OutputToFile(outputFile, false, options => options
                        .WithCustomArgument($"-filter:v \"setpts={1 / speedFactor}*PTS\"")
                        .WithCustomArgument($"-filter:a \"atempo={speedFactor}\""))
                    .ProcessAsynchronously();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"调整视频速度失败: {ex.Message}");
                return false;
            }
        }
    }
}