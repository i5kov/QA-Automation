using NUnit.Framework;
using PajeObjectModel_Homework.Pages.DemoQA;
using System;
using System.Collections.Generic;
using System.Text;

namespace PajeObjectModel_Homework.Tests.InteractionDemoQA
{
    class DragabbleTests : BaseTest
    {
        [SetUp]
        public void Befor_eEachTest()
        {
            StartBrowser();
            NavigateToURL(URLs.DemoQASite);
            new HomePage(Driver).GoToInteractionsMenu().NavigateToInteractionsSection("Draggable");

        }

        [Test]
        public void Test1_SimpleDraggable_Verify_DragBox_Position_Changed()
        {
            Console.WriteLine('x');
        }
    }
}
