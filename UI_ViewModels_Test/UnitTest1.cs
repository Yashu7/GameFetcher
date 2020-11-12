using System;
using System.Windows.Controls;
using DesktopUI_Logic;
using DesktopUI_Logic.Models;
using GameFetcherUI;
using GameFetcherUI.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UI_ViewModels_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsGamesNullTest()
        {
            AddGamePageViewModel addPage = new AddGamePageViewModel();
            addPage.EmptyOutFields();
            Assert.IsTrue(addPage.Games == null);
        }
        [TestMethod]
        public void GameStatusTest()
        {
            StaticData.Instance.Model = new GameDetailsModel() { Id = 1, Name = "Game1" };
            GameStatusViewModel gameStatus = new GameStatusViewModel();
            Assert.IsTrue(gameStatus.Game.Id == 1);
            
        }
        [TestMethod]
        public void PostCommandTest()
        {
            ToSqlConnection sqlConn = new ToSqlConnection();
            GameDetailsModel game = new GameDetailsModel() { Id=2,Name = null };
            try
            {
                sqlConn.PostCommand(game);
                Assert.Fail();
            } catch (Exception)
            {
                
            }
        }
       [TestMethod]
       public void UpdateCommandTest()
        {
            ToSqlConnection sqlConn = new ToSqlConnection();
            GameDetailsModel game = new GameDetailsModel() { Id = -1, Name = null };
            try
            {
                sqlConn.PostCommand(game);
                Assert.Fail();
            }
            catch (Exception)
            {

            }
        }

    }
}
