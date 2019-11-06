using Applitools;
using Applitools.Appium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace ApplitoolsTutorial
{

    [TestFixture]
    public class BasicDemo
    {

        private RemoteWebDriver driver;
        private Eyes eyes;

        [Test]
        public void AndroidTest()
        {
            // Initialize the eyes SDK (IMPORTANT: make sure your API key is set in the APPLITOOLS_API_KEY env variable).
            eyes = new Eyes();

            // Set the desired capabilities.
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("deviceName", "Samsung Galaxy S9 WQHD GoogleAPI Emulator");
            caps.SetCapability("deviceOrientation", "portrait");
            caps.SetCapability("browserName", "");
            caps.SetCapability("platformVersion", "9.0");
            caps.SetCapability("platformName", "Android");
            caps.SetCapability("app", "https://applitools.bintray.com/Examples/eyes-hello-world.apk");
            caps.SetCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            caps.SetCapability("accesskey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            caps.SetCapability("name", "Android Demo");

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com/wd/hub"), caps);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            // Start visual UI testing.
            eyes.Open(driver, "Contacts!", "My first Appium native C# test!");

            // Visual UI testing.
            eyes.CheckWindow("Contact list!");

            // End the test.
            eyes.Close();
        }

        [TearDown]
        public void AfterEach()
        {
            // Close the browser.
            driver.Quit();

            // If the test was aborted before eyes.close was called, ends the test as aborted.
            eyes.AbortIfNotClosed();
        }

    }
}
