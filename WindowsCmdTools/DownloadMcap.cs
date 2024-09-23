
namespace MultiplyManageProtoBuffer
{
    internal class DownloadMcap
    {
        public void DownloadS3Mcap(string? s3DownloadPath, string? targetPath)
        {
            if (string.IsNullOrEmpty(s3DownloadPath))
            {
                Console.WriteLine("输入地址不仅能为空");
                return;
            }
            if (string.IsNullOrEmpty(targetPath))
            {
                targetPath = "C:\\Users\\wangtianbo\\Desktop\\e2e测试数据\\Mcap数据\\" + Path.GetFileName(s3DownloadPath);
                Console.WriteLine("目标路径为空，自动设置为：" + targetPath);
            }
            Command command = new Command();
            command.Output += Command_Output;
            command.Error += Command_Error;
            command.Exited += Command_Exited;
            command.RunCMD($"aws --endpoint-url=http://oss-internal.i.brainpp.cn:80 s3 cp {s3DownloadPath} {targetPath}");

            Console.ReadLine();
        }

        void Command_Exited()
        {
            Console.WriteLine("已退出");
        }

        void Command_Error(string msg)
        {
            Console.WriteLine(msg);
        }

        void Command_Output(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
