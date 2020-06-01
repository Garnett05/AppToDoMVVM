using AppToDo.ViewModels;
using AppToDo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ToDo.Tests
{
    public class ToDoViewModelTests
    {
        [Fact]
        public void ViewModel_populates_items_correctly()
        {
            //Arrange
            //ToDoViewModel viewModel = new ToDoViewModel();
            //Act
            //Assert
            //Assert.Equal(5, viewModel.Items.Count);
        }
        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            //Arrange
            //ToDoViewModel viewModel = new ToDoViewModel();
            //Act
            //viewModel.AddItemCommand.Execute(null);
            //Assert
            //Assert.Equal(6, viewModel.Items.Count);
            //Assert.Equal("ToDo Item 6", viewModel.Items.Last().Name);
        }
        [Fact]
        public void MarkAsCompletedCommand_updates_progress()
        {
            /*/var viewModel = new ToDoViewModel();
            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.Equal("Completed 1/5", viewModel.CompletedHeader);
            Assert.Equal(0.2, viewModel.CompletedProgress);*/
        }
    }
}
