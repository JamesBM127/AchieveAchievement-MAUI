using AchieveAchievementLibrary.JBMException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AATest
{
    public class CustomExceptionTests
    {
        [Test]
        public void IsBusyException_ThrowDefaultMessage_Success()
        {
            #region Arrange
            string expectedMessage = "Another operation is running, try again if the problem persist, restart the app!";
            #endregion

            #region Act && Assert
            IsBusyException? ex = Assert.Throws<IsBusyException>(() => { throw new IsBusyException(); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }

        [Test]
        public void IsBusyException_ThrowCustomMessage_Success()
        {
            #region Arrange
            string expectedMessage = "The app is busy!";
            #endregion

            #region Act && Assert
            IsBusyException? ex = Assert.Throws<IsBusyException>(() => { throw new IsBusyException(expectedMessage); });
            Assert.That(expectedMessage, Is.EqualTo(ex.Message));
            #endregion
        }
    }
}
