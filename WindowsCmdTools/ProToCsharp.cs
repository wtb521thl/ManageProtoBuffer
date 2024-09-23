
namespace MultiplyManageProtoBuffer
{
    internal class ProToCsharp
    {
        public void StartCommand()
        {
            string baseDir = "D:\\Software\\protoc-27.3-win64\\bin\\";


            string tempInputDirStr = "DatasInput";
            string tempOutputDirStr = "DatasOutput";

            string[] files = Directory.GetFiles(baseDir + tempInputDirStr, "*.proto", SearchOption.AllDirectories);

            Command command = new Command();
            command.Output += Command_Output;
            command.Error += Command_Error;
            command.Exited += Command_Exited;
            command.RunCMD($"cd {baseDir}");

            Console.ReadLine();
            //向cmd窗口发送输入信息

            Console.WriteLine("总数：" + files.Length);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine("第几个：" + i.ToString());
                //string tempInputFileRPath = files[i].Replace(baseDir, ".\\");

                string tempOutputFileDir = Path.GetDirectoryName(files[i]).Replace(tempInputDirStr, tempOutputDirStr);
                Console.WriteLine("files[i]：" + files[i]);
                Console.WriteLine("tempOutputFileDir：" + tempOutputFileDir);

                string tempCommand = $"protoc --proto_path={baseDir + tempInputDirStr}  --csharp_out={tempOutputFileDir}  {files[i]}";

                Console.WriteLine("tempCommand：" + tempCommand);

                if (!Directory.Exists(tempOutputFileDir))
                {
                    Directory.CreateDirectory(tempOutputFileDir);
                }


                // protoc --proto_path=D:\Software\protoc-27.3-win64\bin --csharp_out=.\DatasOutput\  D:\Software\protoc-27.3-win64\bin\proto\mviz\builtins\LocationFix.proto

                //Console.WriteLine(tempCommand);

                Console.WriteLine("执行：" + i.ToString());

                command.RunCMD(tempCommand);

            }
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
