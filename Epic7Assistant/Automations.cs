using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Epic7Assistant.Properties;
using System.IO;
using OpenCvSharp;
using System.Reflection;

namespace Epic7Assistant
{
    class Automations
    {
        Epic7AssistantGUI gGui;

        bool gHunt;
        bool gAP;
        bool gEvent;
        bool gExped;
        bool gShopRef;
        bool g1080p;
        bool g1440p;
        bool g4k;
        bool gStatus;
        bool gItemFoundInShop;
        bool gBailOut;
        bool gBookmarkPurchased;
        bool gMysticPurchased;

        int gTimeBetweenClicks;
        int gPointX;
        int gPointY;
        int gPointXenergy;
        int gPointYenergy;
        int gCycleCounter;
        int gBookmarkCount;
        int gMysticCount;
        int gRefreshCount;

        double gXCoord;
        double gYCoord;

        OpenCvSharp.Point gXPoint;
        OpenCvSharp.Point gPointOfItem;

        string gFilePathRepeat;
        string gFilePathFailed;
        string gFilePathInventoryFull;
        string gFilePathEnergy;
        string gFilePathExpedOver;
        string gFilePathExpedDamage;
        string gFilePathExpedEnter;
        string gFilePathExpedVictory;
        string gFilePathExpedConfirm;
        string gFilePathExpedDamageRanking;
        string gFilePathConnectionError;


        public Automations(Epic7AssistantGUI gui, bool hunt, bool ap, bool events, bool expeditions, bool shopRef, bool resolution1080, bool resolution1440, bool resolution4k)
        {
            gGui = gui;
            gHunt = hunt;
            gAP = ap;
            gEvent = events;
            gExped = expeditions;
            gShopRef = shopRef;
            g1080p = resolution1080;
            g1440p = resolution1440;
            g4k = resolution4k;
            gTimeBetweenClicks = 5000;
            gStatus = false;
            gCycleCounter = 0;

            // Set resolutions
            if (g1080p)
            {
                // Harcoded resolution numbers for main button area: Confirm / Try Again / Restart. 
                gPointX = Globals.PointX1080;
                gPointY = Globals.PointY1080;

                gPointXenergy = Globals.PointX1080energy;
                gPointYenergy = Globals.PointY1080energy;
                gFilePathRepeat = Globals.filePathRepeat1080;
                gFilePathFailed = Globals.filePathFailed1080;
                gFilePathInventoryFull = Globals.filePathInventory1080;
                gFilePathEnergy = Globals.filePathEnergy1080;
                gFilePathExpedOver = Globals.filePathExpedOver1080;
                gFilePathExpedDamage = Globals.filePathExpedDamage1080;
                gFilePathExpedEnter = Globals.filePathExpedEnter1080;
                gFilePathExpedVictory = Globals.filePathExpedVictory1080;
                gFilePathExpedConfirm = Globals.filePathExpedConfirm1080;
                gFilePathExpedDamageRanking = Globals.filePathExpedDamageRanking1080;
                gFilePathConnectionError = Globals.filePathConnectionError1080;
            }
            else if(g1440p)
            {
                // Harcoded resolution numbers for main button area: Confirm / Try Again / Restart. 
                gPointX = Globals.PointX1440;
                gPointY = Globals.PointY1440;

                gPointXenergy = Globals.PointX1440energy;
                gPointYenergy = Globals.PointY1440energy;
                gFilePathRepeat = Globals.filePathRepeat1440;
                gFilePathFailed = Globals.filePathFailed1440;
                gFilePathInventoryFull = Globals.filePathInventory1440;
                gFilePathEnergy = Globals.filePathEnergy1440;
            }
            else
            {
                // Harcoded resolution numbers for main button area: Confirm / Try Again / Restart. 
                gPointX = Globals.PointX4k;
                gPointY = Globals.PointY4k;

                gPointXenergy = Globals.PointX4kenergy;
                gPointYenergy = Globals.PointY4kenergy;
                gFilePathRepeat = Globals.filePathRepeat4k;
                gFilePathFailed = Globals.filePathFailed4k;
                gFilePathInventoryFull = Globals.filePathInventory4k;
                gFilePathEnergy = Globals.filePathEnergy4k;
            }

            if (gHunt)
            {
                gui.UpdateLogs("Hunt started!");

                // Run Hunt function
                while (!Globals.Cancelled)
                {
                    InventoryCheck();

                    if(gStatus)
                    {
                        break;
                    }

                    Thread.Sleep(30000);
                    RunHunt();
                }

                Console.WriteLine("Run complete!");
            }
            else if(gAP)
            {
                // Run AP function
                while (!Globals.Cancelled)
                {
                    InventoryCheck();

                    if (gStatus)
                    {
                        break;
                    }

                    Thread.Sleep(30000);
                    RunAP();
                }

                Console.WriteLine("Run complete!");
            }
            else if(gEvent)
            {
                // Run Event function
                RunEvent();
            }
            else if(gExped)
            {
                // Run Exped function
                while (!Globals.Cancelled)
                {

                    if (gStatus)
                    {
                        break;
                    }

                    Thread.Sleep(5000);
                    RunExpeditions();
                }

                Console.WriteLine("Run complete!");
            }
            else if(gShopRef)
            {
                gTimeBetweenClicks = 1000;

                // Run Exped function
                while (!Globals.Cancelled)
                {
                    gBailOut = false;
                    gBookmarkPurchased = false;
                    gMysticPurchased = false;

                    if (gStatus)
                    {
                        break;
                    }

                    Thread.Sleep(5000);

                    // Run the shop refresh checks and purchase on the opening screen
                    RunShopRefresh();

                    if(gBailOut)
                    {
                        break;
                    }

                    // Scroll the screen down regardless if we found anything
                    ScrollScreen();

                    // Check the bottom of the screen for anything
                    RunShopRefresh();

                    if (gBailOut)
                    {
                        break;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("Bookmarks found: " + gBookmarkCount.ToString());
                    Console.WriteLine("Mystics found: " + gMysticCount.ToString());
                    Console.WriteLine("");

                    // Finally refresh the shop.
                    RefreshShop();
                }

                Console.WriteLine("Run complete!");
            }
        }

        private void RunHunt()
        {
            // Init coords
            int x;
            int y;

            // Check for any connection error off the rip.
            ConnectionErrorCheck();

            // Looking to see if "arrange" button in the top right corner after finishing a battle is selectable or not.
            if (!ImageExistsOnScreen(gFilePathRepeat))
            {
                //If it is NOT selectable, that means the current cycle of the battle is still going and we only need to check for errors.
                ConnectionErrorCheck();
                gGui.UpdateLogs("The hunt continues...");
            }
            else
            {
                gCycleCounter++;
                gGui.UpdateLogs("Total Cycle Count Hunt: " + gCycleCounter);

                if (ImageExistsOnScreen(gFilePathFailed))
                {
                    gGui.UpdateLogs("Finished cycle on failed. Intializing failed steps.");

                    // Set coords
                    x = gPointOfItem.X;
                    y = gPointOfItem.Y;

                    Cursor.Position = new System.Drawing.Point(x, y);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);

                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        // Set coords
                        x = gPointOfItem.X;
                        y = gPointOfItem.Y;

                        gGui.UpdateLogs("We found energy button.");
                        EnergyCheck(x, y);
                    }
                    

                }
                else
                {
                    gGui.UpdateLogs("Battle has ended normally. Restarting battle.");
                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);


                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        // Set coords
                        x = gPointOfItem.X;
                        y = gPointOfItem.Y;

                        gGui.UpdateLogs("We found energy button.");
                        EnergyCheck(x, y);
                    }
                }
            }
        }

        private void RunAP()
        {
            // Init coords
            int x;
            int y;

            // Check for any connection error off the rip.
            ConnectionErrorCheck();

            // Looking to see if arrange is selectable or not.
            if (!ImageExistsOnScreen(gFilePathRepeat))
            {
                //If it is NOT selectable, that means the current cycle of the battle is still going and we only need to check for errors.
                ConnectionErrorCheck();
                gGui.UpdateLogs("The journey continues...");
            }
            else
            {
                gCycleCounter++;
                gGui.UpdateLogs("Total Cycle Count AP: " + gCycleCounter);

                if (ImageExistsOnScreen(gFilePathFailed))
                {
                    gGui.UpdateLogs("Finished cycle on failed. Intializing failed steps.");

                    // Set coords
                    x = gPointOfItem.X;
                    y = gPointOfItem.Y;

                    Cursor.Position = new System.Drawing.Point(x, y);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);

                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        // Set coords
                        x = gPointOfItem.X;
                        y = gPointOfItem.Y;

                        gGui.UpdateLogs("We found energy button.");
                        EnergyCheck(x, y);
                    }

                }
                else
                {
                    gGui.UpdateLogs("Battle has ended normally. Restarting battle.");
                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);

                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        // Set coords
                        x = gPointOfItem.X;
                        y = gPointOfItem.Y;

                        gGui.UpdateLogs("We found energy button.");
                        EnergyCheck(x, y);
                    }
                }
            }
        }

        private void RunEvent()
        {
            // TODO - Not yet supported.
        }

        private void RunShopRefresh()
        {
            gItemFoundInShop = false;

            // Check if we have bookmarks and / or mystics on the current screen
            bool bookmark = ImageExistsOnScreen(Globals.filePathShopBookmark1080);
            bool mystics = ImageExistsOnScreen(Globals.filePathShopMystics1080);

            // Found both
            if (bookmark && mystics)
            {
                gItemFoundInShop = true;

                // Increment both
                gBookmarkCount++;
                gMysticCount++;

                Console.WriteLine("Bookmark AND mystics found!");

                // Get the current coords for the bookmark
                ImageExistsOnScreen(Globals.filePathShopBookmark1080);

                // Set coords for bookmark
                int x = gPointOfItem.X;
                int y = gPointOfItem.Y;

                //Set our cursor to the top left of the item icon. 853 / 371
                Cursor.Position = new System.Drawing.Point(x, y);
                Thread.Sleep(gTimeBetweenClicks);

                // This is the location for its respective button
                // So in this case, its add 847 to go over to the right as much as we need. 1700 og
                // Then for down adjustment, add 79/ 450 og
                Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(gTimeBetweenClicks);


                int maxPurchase = 0;
                // Check if buy showed up. Just in case buy button failed to recognize click
                while(!ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {

                    if (gBookmarkPurchased)
                    {
                        Console.WriteLine("Click did not work because we already purchased that bookmark.");
                        break;
                    }

                    // While we dont see the buy button, try again 
                    maxPurchase++;
                    Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    if(maxPurchase > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if(gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                // Buy the bookmark
                ClickPurchaseButton();
                Thread.Sleep(1000);

                int maxTries = 0;
                // Lets check for cancel still.
                while (ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {
                    Console.WriteLine("Final purchase click didnt work.. trying again");
                    // While we dont see the buy button, try again 
                    maxTries++;

                    ClickPurchaseButton();

                    if (maxTries > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if (gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                gBookmarkPurchased = true;

                // Since this is double we need to grab the mystics
                ImageExistsOnScreen(Globals.filePathShopMystics1080);

                // Set coords to mystic now
                x = gPointOfItem.X;
                y = gPointOfItem.Y;

                // Set our cursor to the top left of the item icon.
                Cursor.Position = new System.Drawing.Point(x, y);
                Thread.Sleep(gTimeBetweenClicks);

                // Now move to the buy button for it
                Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(gTimeBetweenClicks);

                int maxPurchaseTwo = 0;
                // Check if buy showed up. Just in case buy button failed to recognize click
                while (!ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {
                    if (gMysticPurchased)
                    {
                        Console.WriteLine("Click did not work because we already purchased that mystic.");
                        break;
                    }

                    // While we dont see the buy button, try again 
                    maxPurchaseTwo++;
                    Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    if (maxPurchaseTwo > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if (gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                // Buy the mystics
                ClickPurchaseButton();
                Thread.Sleep(1000);

                int maxTriesTwo = 0;
                // Lets check for cancel still.
                while (ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {
                    Console.WriteLine("Final purchase click didnt work.. trying again");
                    // While we dont see the buy button, try again 
                    maxTriesTwo++;

                    ClickPurchaseButton();

                    if (maxTriesTwo > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if (gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                gMysticPurchased = true;
            }
            // Found one or the other
            else if (bookmark || mystics)
            {
                gItemFoundInShop = true;

                int x;
                int y;

                if (bookmark)
                {
                    Console.WriteLine("Bookmark found!");
                    bookmark = ImageExistsOnScreen(Globals.filePathShopBookmark1080);

                    // Set coords
                    x = gPointOfItem.X;
                    y = gPointOfItem.Y;
                    gBookmarkCount++;
                }
                else
                {
                    Console.WriteLine("Mystic found!");
                    mystics = ImageExistsOnScreen(Globals.filePathShopMystics1080);

                    // Set coords
                    x = gPointOfItem.X;
                    y = gPointOfItem.Y;
                    gMysticCount++;
                }

                //Set our cursor to the top left of the item icon. 853 / 371
                Cursor.Position = new System.Drawing.Point(x, y);
                Thread.Sleep(gTimeBetweenClicks);

                // This is the location for its respective button
                // So in this case, its add 847 to go over to the right as much as we need. 1700 og
                // Then for down adjustment, add 79/ 450 og
                Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(gTimeBetweenClicks);

                int maxPurchaseTwo = 0;
                // Check if buy showed up. Just in case buy button failed to recognize click
                while (!ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {
                    if(gMysticPurchased || gBookmarkPurchased)
                    {
                        Console.WriteLine("Click did not work because we already purchased that item.");
                        break;
                    }

                    // While we dont see the buy button, try again 
                    Console.WriteLine("Click failed trying again");
                    maxPurchaseTwo++;
                    Cursor.Position = new System.Drawing.Point(x + 847, y + 79);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    if (maxPurchaseTwo > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if (gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                // Buy the item
                ClickPurchaseButton();
                Thread.Sleep(1000);

                int maxTries = 0;
                // Lets check for cancel still.
                while (ImageExistsOnScreen(Globals.filePathShopCancel1080))
                {
                    Console.WriteLine("Final purchase click didnt work.. trying again");
                    // While we dont see the buy button, try again 
                    maxTries++;

                    ClickPurchaseButton();

                    if (maxTries > 12)
                    {
                        gBailOut = true;
                        break;
                    }
                }

                if (gBailOut)
                {
                    Console.WriteLine("Something went wrong, gotta bail out.");
                    return;
                }

                if (bookmark)
                {
                    gBookmarkPurchased = true;
                }
                {
                    gMysticPurchased = true;
                }
            }
            else
            {
                Console.WriteLine("Did not find any bookmarks or mystics...");
                gItemFoundInShop = false;
            }
        }

        private void RunExpeditions()
        {

            // Click the open recruitment tab
            Cursor.Position = new System.Drawing.Point(1400, 250);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            // Click on level 2
            Cursor.Position = new System.Drawing.Point(1100, 330);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            // Click on Refresh
            Cursor.Position = new System.Drawing.Point(1750, 330);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(3000);

            // While there is NOT an enter on the screen, we refresh and wait.
            while(!ImageExistsOnScreen(gFilePathExpedEnter))
            {
                Console.WriteLine("Refresh did not populate an battle. Lets try again and check.");
                Thread.Sleep(10000);

                // Click on Refresh
                Cursor.Position = new System.Drawing.Point(1750, 330);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                Thread.Sleep(3000);

            }

            // Click on first one
            Cursor.Position = new System.Drawing.Point(1750, 480);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(1000);
            VirtualMouse.LeftClick();

            if (ExpedOverCheck())
            {
                return;
            }

            // While we did not see a damage ranking come up after clicking the first one. Lets try to refresh broken button
            while (!ImageExistsOnScreen(gFilePathExpedDamageRanking))
            {
                // Click on private tab
                Cursor.Position = new System.Drawing.Point(1200, 250);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                Thread.Sleep(1000);

                // Click the open recruitment tab
                Cursor.Position = new System.Drawing.Point(1400, 250);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                // Click on Refresh
                Cursor.Position = new System.Drawing.Point(1750, 330);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(3000);

                // Click on first one
                Cursor.Position = new System.Drawing.Point(1750, 480);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(1000);
                VirtualMouse.LeftClick();

                if (ExpedOverCheck())
                {
                    return;
                }
            }

            if (ExpedOverCheck())
            {
                return;
            }


            // Now click ready
            Cursor.Position = new System.Drawing.Point(1710, 1000);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            if(ExpedOverCheck())
            {
                return;
            }

            // Now click start
            Cursor.Position = new System.Drawing.Point(1710, 1000);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            if (ExpedOverCheck())
            {
                return;
            }

            int i = 0;
            // Keep clicking start until it works.
            while (!ImageExistsOnScreen(gFilePathExpedConfirm))
            {
                Thread.Sleep(1000);
                i++;

                // Now click start
                Cursor.Position = new System.Drawing.Point(1710, 1000);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                if(i > 10)
                {
                    Console.WriteLine("Someone went wrong and fell out of sync... fixing...");
                    return;
                }
            }

            if (ExpedOverCheck())
            {
                return;
            }

            // Now click confirm
            Cursor.Position = new System.Drawing.Point(950, 800);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(1000);

            if (ExpedOverCheck())
            {
                return;
            }

            int j = 0;
            // Keep clicking confirm until it works.
            while (ImageExistsOnScreen(gFilePathExpedConfirm))
            {
                Thread.Sleep(1000);
                j++;

                // Now click confirm
                Cursor.Position = new System.Drawing.Point(950, 800);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                if (j > 10)
                {
                    Console.WriteLine("Someone went wrong and fell out of sync... fixing...");
                    return;
                }
            }

            if (ExpedOverCheck())
            {
                return;
            }

            // Wait for battle
            while (!ImageExistsOnScreen(gFilePathExpedDamage))
            {
                //TODO Add check for something that tells us we are on the wrong screen and return. This should help us reset

                Thread.Sleep(10000);
                Console.WriteLine("Battle running...");
            }

            Console.WriteLine("Detected completed battle!");

            // Now click Confirm (bottom right)
            Cursor.Position = new System.Drawing.Point(1710, 1000);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(1000);

            // Check for victory box
            if (ImageExistsOnScreen(gFilePathExpedVictory))
            {
                // Now click close
                Cursor.Position = new System.Drawing.Point(950, 800);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
            }
            else
            {
                // Now click back out of exped, might just let it time out instead. We shall test
                Cursor.Position = new System.Drawing.Point(40, 40);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
            }

        }

        private void RefreshShop()
        {
            // Refresh location
            Cursor.Position = new System.Drawing.Point(330, 975);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            // Confirm location
            Cursor.Position = new System.Drawing.Point(1050, 650);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();

            gRefreshCount++;

            Console.WriteLine("We have refreshed a total of " + gRefreshCount.ToString() + " times.");
        }

        private void ClickPurchaseButton()
        {
            // final purchase button
            Cursor.Position = new System.Drawing.Point(1000, 780);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
        }

        private void ScrollScreen()
        {
            Console.WriteLine("Scrolling...");
            Cursor.Position = new System.Drawing.Point(1000, 780);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.WheelDown();
            Thread.Sleep(3000);
        }

        private bool ExpedOverCheck()
        {
            Thread.Sleep(2000);

            // Check for Exped over message
            if (ImageExistsOnScreen(gFilePathExpedOver) || ImageExistsOnScreen(gFilePathExpedVictory))
            {
                Console.WriteLine("Exped was over...");

                Cursor.Position = new System.Drawing.Point(950, 800);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();

                return true;
            }

            return false;
        }

        private void EnergyCheck(int xCoordBuyEnergy, int yCoordBuyEnergy)
        {
            // Move cursor to location to purchase energy.
            gGui.UpdateLogs("Purchasing Energy");
            Cursor.Position = new System.Drawing.Point(xCoordBuyEnergy, yCoordBuyEnergy);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            gGui.UpdateLogs("Energy Purchased");

            // Reposition mouse back to main button area on bottom right.
            Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(gTimeBetweenClicks);
        }

        private void InventoryCheck()
        {
            if(ImageExistsOnScreen(gFilePathInventoryFull))
            {
                gGui.UpdateLogs("Inventory Full. Job Complete");
                gStatus = true;
            }
            else
            {
                //Inventory not Full. Moving on.
                gStatus = false;
            }
        }

        private void ConnectionErrorCheck()
        {
            if (ImageExistsOnScreen(gFilePathConnectionError))
            {
                gGui.UpdateLogs("Found connection error message on screen. Removing message and attempting to move on.");

                int x = gPointOfItem.X;
                int y = gPointOfItem.Y;

                // Move to error message
                Cursor.Position = new System.Drawing.Point(x, y);
                Thread.Sleep(gTimeBetweenClicks);
                VirtualMouse.LeftClick();
                Thread.Sleep(gTimeBetweenClicks);

                // Move back to main button area.
                Cursor.Position = new System.Drawing.Point(gPointX, gPointY);

            }
        }


        private bool ImageExistsOnScreen(string imageFileName)
        {
            using (Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                                         Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                {
                    g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                     Screen.PrimaryScreen.Bounds.Y,
                                     0, 0,
                                     bmpScreenCapture.Size,
                                     CopyPixelOperation.SourceCopy);
                }
                using (Mat screen = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmpScreenCapture))
                using (Mat image = Cv2.ImRead(imageFileName, ImreadModes.Grayscale)) //Convert the image to grayscale
                {
                    Mat screenGray = new Mat();
                    Cv2.CvtColor(screen, screenGray, ColorConversionCodes.BGRA2GRAY);
                    Mat result = new Mat();
                    Cv2.MatchTemplate(screenGray, image, result, TemplateMatchModes.CCoeffNormed);
                    Cv2.MinMaxLoc(result, out gXCoord, out gYCoord, out gXPoint, out gPointOfItem);
                    Cv2.Threshold(result, result, 0.9, 1.0, ThresholdTypes.Tozero);

                    screen.Dispose();
                    image.Dispose();
                    bmpScreenCapture.Dispose();
                    screenGray.Dispose();

                    bool tempResult = Cv2.CountNonZero(result) > 0;

                    result.Dispose();

                    return tempResult;
                }
            }
        }

        public static class VirtualMouse
        {
            [DllImport("user32.dll")]
            static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
            private const int MOUSEEVENTF_MOVE = 0x0001;
            private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            private const int MOUSEEVENTF_LEFTUP = 0x0004;
            private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            private const int MOUSEEVENTF_RIGHTUP = 0x0010;
            private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
            private const int MOUSEEVENTF_ABSOLUTE = 0x8000;
            private const int MOUSEEVENTF_WHEEL = 0x0800;
            public static void Move(int xDelta, int yDelta)
            {
                mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
            }
            public static void MoveTo(int x, int y)
            {
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, x, y, 0, 0);
            }
            public static void LeftClick()
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void LeftDown()
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void LeftUp()
            {
                mouse_event(MOUSEEVENTF_LEFTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightClick()
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
                mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightDown()
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void RightUp()
            {
                mouse_event(MOUSEEVENTF_RIGHTUP, System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y, 0, 0);
            }

            public static void WheelDown()
            {
                mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -120, 0);
            }
        }

    }

        /*
        
        private bool ScanForImage(Bitmap myPic)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Bitmap screenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);


            Graphics g = Graphics.FromImage(screenCapture);

            g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                             Screen.PrimaryScreen.Bounds.Y,
                             0, 0,
                             screenCapture.Size,
                             CopyPixelOperation.SourceCopy);

            //Bitmap myPic = Resources.arrangeSelectable1080;

            bool isInCapture = IsInCapture(myPic, screenCapture);

            screenCapture.Dispose();
            myPic.Dispose();
            g.Dispose();

            sw.Stop();


            TimeSpan ts = sw.Elapsed;

            if (isInCapture)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsInCapture(Bitmap searchFor, Bitmap searchIn)
        {
            int isTrueCounter = 0;

            for (int x = 0; x < searchIn.Width; x++)
            {
                for (int y = 0; y < searchIn.Height; y++)
                {
                    bool invalid = false;
                    int k = x, l = y;

                    for (int a = 0; a < searchFor.Width; a++)
                    {
                        l = y;
                        for (int b = 0; b < searchFor.Height; b++)
                        {
                            if (searchFor.GetPixel(a, b) != searchIn.GetPixel(k, l))
                            {
                                invalid = true;
                                break;
                            }
                            else
                            {
                                isTrueCounter++;
                                l++;
                            }
                        }
                        if (invalid)
                        {
                            break;
                        }
                        else
                        {
                            k++;
                        }
                    }
                    if (!invalid)
                        return true;
                }
            }
            Console.WriteLine("Pixel Count that wasnt found " + isTrueCounter);
            return false;
        }
        */
        
    }

