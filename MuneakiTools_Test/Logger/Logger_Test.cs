using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuneakiTools.Logger;
using MuneakiTools.OriginalException;
using Xunit;

namespace Tools_Test.Logger
{
    public class Logger_Test
    {
        private const string DefoltMassage = "test";
        private const Level DefoltLevel = Level.Debug;

        private readonly MuneakiTools.Logger.Logger logger = new MuneakiTools.Logger.Logger();

        [Fact]
        public void インスタンス化できる()
        {
            var logger = new MuneakiTools.Logger.Logger();

            Assert.IsType<MuneakiTools.Logger.Logger>(logger);
        }

        [Fact]
        public void 正常な引数を渡したら例外をスローしない()
        {
            this.logger.Log(DefoltLevel, DefoltMassage);

            // 上で失敗しなければ成功
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void massageに空文字やnullを渡しても例外をスローしない(string? massage)
        {
            this.logger.Log(DefoltLevel, massage);

            // 上で失敗しなければ成功
        }

        [Fact]
        public void メッセージにカンマ入りの文字列を渡すと例外をスローする()
        {
            Assert.Throws<ArgumentException>(() => this.logger.Log(DefoltLevel, DefoltMassage + "," + DefoltMassage));
        }
    }
}
