using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Maui.Storage;
using VideoMaker.Services;

namespace VideoMaker.Pages
{
    public partial class VideoEditPage : ContentPage
    {
        private readonly FFmpegService _ffmpegService;
        private string _selectedVideoPath;
        private string _selectedWatermarkPath;
        private List<string> _selectedVideosForMerge = new List<string>();

        public VideoEditPage()
        {
            InitializeComponent();
            //_ffmpegService = ffmpegService;

            // 设置速度滑块的值变化事件
            SliderSpeed.ValueChanged += (s, e) =>
            {
                double value = Math.Round(e.NewValue, 1);
                LblSpeedFactor.Text = $"速度: {value}x";
            };
        }

        private async void OnSelectVideoClicked(object sender, EventArgs e)
        {
            //try
            //{
            //    var result = await FilePicker.PickAsync(new PickOptions
            //    {
            //        FileTypes = FilePickerFileType.Videos,
            //        PickerTitle = "选择视频文件"
            //    });

            //    if (result != null)
            //    {
            //        _selectedVideoPath = result.FullPath;
            //        LblSelectedVideo.Text = Path.GetFileName(_selectedVideoPath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("错误", $"选择文件时出错: {ex.Message}", "确定");
            //}
        }

        private async void OnTrimVideoClicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_selectedVideoPath))
            //{
            //    await DisplayAlert("提示", "请先选择视频文件", "确定");
            //    return;
            //}

            //if (!TimeSpan.TryParse(EntryStartTime.Text, out TimeSpan startTime) ||
            //    !TimeSpan.TryParse(EntryDuration.Text, out TimeSpan duration))
            //{
            //    await DisplayAlert("提示", "请输入有效的时间格式 (HH:MM:SS)", "确定");
            //    return;
            //}

            //try
            //{
            //    LoadingIndicator.IsVisible = true;
            //    LoadingIndicator.IsRunning = true;
            //    LblStatus.Text = "正在处理...";

            //    string outputFile = Path.Combine(
            //        Path.GetDirectoryName(_selectedVideoPath),
            //        $"{Path.GetFileNameWithoutExtension(_selectedVideoPath)}_trimmed{Path.GetExtension(_selectedVideoPath)}");

            //    bool success = await _ffmpegService.TrimVideoAsync(_selectedVideoPath, outputFile, startTime, duration);

            //    if (success)
            //    {
            //        LblStatus.Text = "视频剪切成功!";
            //        await DisplayAlert("成功", $"视频已保存至: {outputFile}", "确定");
            //    }
            //    else
            //    {
            //        LblStatus.Text = "视频剪切失败!";
            //        await DisplayAlert("错误", "视频剪切失败，请查看日志", "确定");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblStatus.Text = "处理出错!";
            //    await DisplayAlert("错误", $"处理视频时出错: {ex.Message}", "确定");
            //}
            //finally
            //{
            //    LoadingIndicator.IsVisible = false;
            //    LoadingIndicator.IsRunning = false;
            //}
        }

        private async void OnSelectVideosForMergeClicked(object sender, EventArgs e)
        {
            //try
            //{
            //    var result = await FilePicker.PickMultipleAsync(new PickOptions
            //    {
            //        FileTypes = FilePickerFileType.Videos,
            //        PickerTitle = "选择多个视频文件"
            //    });

            //    if (result != null && result.Count() > 0)
            //    {
            //        _selectedVideosForMerge = result.Select(f => f.FullPath).ToList();
            //        LblSelectedVideosForMerge.Text = $"已选择 {_selectedVideosForMerge.Count} 个文件";
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("错误", $"选择文件时出错: {ex.Message}", "确定");
            //}
        }

        private async void OnMergeVideosClicked(object sender, EventArgs e)
        {
            //if (_selectedVideosForMerge.Count < 2)
            //{
            //    await DisplayAlert("提示", "请至少选择两个视频文件", "确定");
            //    return;
            //}

            //try
            //{
            //    LoadingIndicator.IsVisible = true;
            //    LoadingIndicator.IsRunning = true;
            //    LblStatus.Text = "正在合并视频...";

            //    string outputFile = Path.Combine(
            //        Path.GetDirectoryName(_selectedVideosForMerge[0]),
            //        $"merged_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(_selectedVideosForMerge[0])}");

            //    bool success = await _ffmpegService.ConcatVideosAsync(_selectedVideosForMerge.ToArray(), outputFile);

            //    if (success)
            //    {
            //        LblStatus.Text = "视频合并成功!";
            //        await DisplayAlert("成功", $"合并后的视频已保存至: {outputFile}", "确定");
            //    }
            //    else
            //    {
            //        LblStatus.Text = "视频合并失败!";
            //        await DisplayAlert("错误", "视频合并失败，请查看日志", "确定");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblStatus.Text = "处理出错!";
            //    await DisplayAlert("错误", $"合并视频时出错: {ex.Message}", "确定");
            //}
            //finally
            //{
            //    LoadingIndicator.IsVisible = false;
            //    LoadingIndicator.IsRunning = false;
            //}
        }

        private async void OnSelectWatermarkClicked(object sender, EventArgs e)
        {
            //try
            //{
            //    var result = await FilePicker.PickAsync(new PickOptions
            //    {
            //        FileTypes = FilePickerFileType.Images,
            //        PickerTitle = "选择水印图片"
            //    });

            //    if (result != null)
            //    {
            //        _selectedWatermarkPath = result.FullPath;
            //        LblSelectedWatermark.Text = Path.GetFileName(_selectedWatermarkPath);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    await DisplayAlert("错误", $"选择文件时出错: {ex.Message}", "确定");
            //}
        }

        private async void OnAddWatermarkClicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_selectedVideoPath))
            //{
            //    await DisplayAlert("提示", "请先选择视频文件", "确定");
            //    return;
            //}

            //if (string.IsNullOrEmpty(_selectedWatermarkPath))
            //{
            //    await DisplayAlert("提示", "请选择水印图片", "确定");
            //    return;
            //}

            //try
            //{
            //    LoadingIndicator.IsVisible = true;
            //    LoadingIndicator.IsRunning = true;
            //    LblStatus.Text = "正在添加水印...";

            //    string outputFile = Path.Combine(
            //        Path.GetDirectoryName(_selectedVideoPath),
            //        $"{Path.GetFileNameWithoutExtension(_selectedVideoPath)}_watermarked{Path.GetExtension(_selectedVideoPath)}");

            //    bool success = await _ffmpegService.AddWatermarkAsync(_selectedVideoPath, _selectedWatermarkPath, outputFile);

            //    if (success)
            //    {
            //        LblStatus.Text = "水印添加成功!";
            //        await DisplayAlert("成功", $"添加水印后的视频已保存至: {outputFile}", "确定");
            //    }
            //    else
            //    {
            //        LblStatus.Text = "水印添加失败!";
            //        await DisplayAlert("错误", "添加水印失败，请查看日志", "确定");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblStatus.Text = "处理出错!";
            //    await DisplayAlert("错误", $"添加水印时出错: {ex.Message}", "确定");
            //}
            //finally
            //{
            //    LoadingIndicator.IsVisible = false;
            //    LoadingIndicator.IsRunning = false;
            //}
        }

        private async void OnChangeSpeedClicked(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(_selectedVideoPath))
            //{
            //    await DisplayAlert("提示", "请先选择视频文件", "确定");
            //    return;
            //}

            //try
            //{
            //    LoadingIndicator.IsVisible = true;
            //    LoadingIndicator.IsRunning = true;
            //    LblStatus.Text = "正在调整视频速度...";

            //    double speedFactor = Math.Round(SliderSpeed.Value, 1);
            //    string outputFile = Path.Combine(
            //        Path.GetDirectoryName(_selectedVideoPath),
            //        $"{Path.GetFileNameWithoutExtension(_selectedVideoPath)}_speed{speedFactor}x{Path.GetExtension(_selectedVideoPath)}");

            //    bool success = await _ffmpegService.ChangeVideoSpeedAsync(_selectedVideoPath, outputFile, speedFactor);

            //    if (success)
            //    {
            //        LblStatus.Text = "视频速度调整成功!";
            //        await DisplayAlert("成功", $"调整速度后的视频已保存至: {outputFile}", "确定");
            //    }
            //    else
            //    {
            //        LblStatus.Text = "视频速度调整失败!";
            //        await DisplayAlert("错误", "调整视频速度失败，请查看日志", "确定");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LblStatus.Text = "处理出错!";
            //    await DisplayAlert("错误", $"调整视频速度时出错: {ex.Message}", "确定");
            //}
            //finally
            //{
            //    LoadingIndicator.IsVisible = false;
            //    LoadingIndicator.IsRunning = false;
            //}
        }
    }
}