using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBaseShared
{
    public enum Mode
    {
        /// <summary>
        /// 手动
        /// </summary>
        Manual = 0,
        /// <summary>
        /// 自动
        /// </summary>
        Auto = 1,
    }
    public interface IServer
    {
        /// <summary>
        /// 开启方式
        /// </summary>
        Mode StartMode { get; }
        /// <summary>
        /// 服务器名称
        /// </summary>
        string ServerName { get; set; }
        /// <summary>
        /// 初始化服务器信息
        /// </summary>
        /// <param name="args"></param>
        void Init(string[] args);
        /// <summary>
        /// 关闭退出服务器
        /// </summary>
        void Exit();
        /// <summary>
        /// 主循环
        /// </summary>
        void Run();
        /// <summary>
        /// 输入
        /// </summary>
        void ProcessInput();
    }
}
