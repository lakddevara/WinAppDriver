﻿//******************************************************************************
//
// Copyright (c) 2017 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace W3CWebDriver
{
    [TestClass]
    public class ElementSize : CalculatorBase
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }

        [TestMethod]
        public void ErrorGetElementSizeNoSuchWindow()
        {
            try
            {
                var size = Utility.GetOrphanedElement().Size;
                Assert.Fail("Exception should have been thrown");
            }
            catch (System.InvalidOperationException exception)
            {
                Assert.AreEqual(ErrorStrings.NoSuchWindow, exception.Message);
            }
        }

        [TestMethod]
        public void ErrorGetElementSizeStaleElement()
        {
            try
            {
                var size = GetStaleElement().Size;
                Assert.Fail("Exception should have been thrown");
            }
            catch (System.InvalidOperationException exception)
            {
                Assert.AreEqual(ErrorStrings.StaleElementReference, exception.Message);
            }
        }

        [TestMethod]
        public void GetElementSize()
        {
            WindowsElement clearButton = session.FindElementByAccessibilityId("clearButton");
            Assert.IsNotNull(clearButton);
            Assert.IsTrue(clearButton.Size.Width > 0);
            Assert.IsTrue(clearButton.Size.Height > 0);

            WindowsElement memButton = session.FindElementByAccessibilityId("memButton");
            Assert.IsNotNull(memButton);
            Assert.IsTrue(memButton.Size.Width > 0);
            Assert.IsTrue(memButton.Size.Height > 0);

            // Clear button is always bigger than Mem button
            Assert.IsTrue(clearButton.Size.Width > memButton.Size.Width);
            Assert.IsTrue(clearButton.Size.Height > memButton.Size.Height);
        }
    }
}
