using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ToDo;
using AppToDo.Services;
using Xamarin.Forms;

namespace ToDo.Tests
{
    public class BoolToTextDecorationConverterTests
    {
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_completed()
        {
            //Arrange
            var conveter = new BoolToTextDecorationConverter();
            //Act
            var result = conveter.Convert(true, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.Strikethrough, (TextDecorations)result);
        }
        [Fact]
        public void Convert_returns_strikethrough_when_item_is_not_completed()
        {
            //Arrange
            var conveter = new BoolToTextDecorationConverter();
            //Act
            var result = conveter.Convert(false, null, null, null);
            //Assert
            Assert.Equal(TextDecorations.None, (TextDecorations)result);
        }
    }
}
