using System;
using Xunit;
using FastHttpWrapperLib;

namespace FastHttpWrapperTests
{
    public class WrapperTests
    {
        [Fact]
        public void Test1()
        {
            var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory =  System.IO.Path.GetDirectoryName(path);

            var fastHttpPath = System.IO.Path.Combine(directory, "fasthttp.exe");

            FastHttpWrapper wrapper = new FastHttpWrapper("../../../../../golang/fasthttp.exe");
            string result = wrapper.DoPost("http://127.0.0.1:5001/api/script/run", "{ 'ScriptName' : 'TESTE', 'Token': '69558fae-7aa8-4095-801f-0df04b14d3c8', 'ScriptParameters' : { 'entrada': 123 } }");


        }
    }
}
