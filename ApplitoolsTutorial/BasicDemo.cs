using Applitools.Appium;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
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
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Samsung Galaxy S9 WQHD GoogleAPI Emulator");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "9.0");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.App, "https://applitools.bintray.com/Examples/eyes-hello-world.apk");
            options.AddAdditionalCapability("deviceOrientation", "portrait");

            options.AddAdditionalCapability("username", Environment.GetEnvironmentVariable("SAUCE_USERNAME"));
            options.AddAdditionalCapability("accesskey", Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY"));
            options.AddAdditionalCapability("name", "Android Demo");

            driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com/wd/hub"), options);
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
