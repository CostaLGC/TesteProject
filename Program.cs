using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
    {
        [TestFixture]
        public class Program
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
            private string baseURL;
            private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new FirefoxDriver();
                baseURL = "https://google.com.br/";
                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void TheSeleniumTest()
            {
                driver.Navigate().GoToUrl(baseURL + "/");
 //               driver.FindElement(By.XPath("html.js.flexbox.flexboxlegacy.canvas.canvastext.no-touch.hashchange.history.draganddrop.rgba.hsla.multiplebgs.backgroundsize.borderimage.borderradius.boxshadow.textshadow.opacity.cssanimations.csscolumns.cssgradients.no-cssreflections.csstransforms.csstransforms3d.csstransitions.fontface.generatedcontent.video.audio.svg.inlinesvg.svgclippaths.js_active.vc_desktop.vc_transform.vc_transform.vc_transform.skrollr.skrollr-desktop body.home-page.bp-nouveau.home.page-template.page-template-full-width.page-template-full-width-php.page.page-id-5353.theme-startit.qode-core-1.3.1.woocommerce-js.startit-ver-2.5.qodef-smooth-scroll.qodef-blog-installed.qodef-top-bar-mobile-hide.qodef-header-standard.qodef-sticky-header-on-scroll-up.qodef-default-mobile-header.qodef-sticky-up-mobile-header.qodef-dropdown-animate-height.qodef-light-header.qodef-search-covers-header.qodef-side-menu-slide-with-content.qodef-width-470.wpb-js-composer.js-comp-ver-5.4.7.vc_responsive.elementor-default.elementor-kit-6021.MauticFocusModal.js div.qodef-wrapper div.qodef-wrapper-inner header.qodef-page-header div.qodef-menu-area div.qodef-grid div.qodef-vertical-align-containers div.qodef-position-right div.qodef-position-right-inner nav.qodef-main-menu.qodef-drop-down.qodef-default-nav ul#menu-main-menu.clearfix li#nav-menu-item-5643.menu-item.menu-item-type-post_type.menu-item-object-page.narrow a span.item_outer span.item_inner span.item_text")).Click();
                driver.FindElement(By.Name("q")).SendKeys("Auto");
                //driver.FindElement(By.CssSelector("#nav-menu-item-5643 > a > span.item_outer > span.item_inner > span.item_text")).Click();
                Assert.IsTrue(IsElementPresent(By.Name("q")));
            }
            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }
