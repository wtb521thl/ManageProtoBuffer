// See https://aka.ms/new-console-template for more information
using MultiplyManageProtoBuffer;

Console.WriteLine("选择功能：1（protobuff），2（下载mcap）");
var keyInfo = Console.ReadKey();
switch (keyInfo.Key)
{
    case ConsoleKey.D1
        :
        ProToCsharp proToCsharp = new ProToCsharp();
        proToCsharp.StartCommand();
        break;
    case ConsoleKey.D2
        :
        Console.WriteLine("当前为下载Mcap模块，请输入下载地址");
        string? tempDownloadPath = Console.ReadLine();
        Console.WriteLine("请输入本地储存地址");
        string? tempTargetPath = Console.ReadLine();
        DownloadMcap downloadMcap = new DownloadMcap();
        downloadMcap.DownloadS3Mcap(tempDownloadPath, tempTargetPath);
        break;
}








