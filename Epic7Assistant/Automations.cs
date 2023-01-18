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

namespace Epic7Assistant
{
    class Automations
    {
        bool gHunt;
        bool gAP;
        bool gEvent;
        bool gExped;
        bool g1080p;
        bool g1440p;
        bool g4k;

        int gTimeBetweenClicks;
        int gPointX;
        int gPointY;

        string gFilePathRepeat;
        string gFilePathFailed;
        string gFilePathInventoryFull;
        string gFilePathEnergy;

        public Automations(Epic7AssistantGUI gui, bool hunt, bool ap, bool events, bool expeditions, bool resolution1080, bool resolution1440, bool resolution4k)
        {
            gHunt = hunt;
            gAP = ap;
            gEvent = events;
            gExped = expeditions;
            g1080p = resolution1080;
            g1440p = resolution1440;
            g4k = resolution4k;
            gTimeBetweenClicks = 4000;

            // Set resolutions
            if(g1080p)
            {
                gPointX = Globals.PointX1080;
                gPointY = Globals.PointY1080;
                gFilePathRepeat = Globals.filePathRepeat1080;
                gFilePathFailed = Globals.filePathFailed1080;
                gFilePathInventoryFull = Globals.filePathInventory1080;
                gFilePathEnergy = Globals.filePathEnergy1080;
            }
            else if(g1440p)
            {
                gPointX = Globals.PointX1440;
                gPointY = Globals.PointY1440;
                gFilePathRepeat = Globals.filePathRepeat1440;
                gFilePathFailed = Globals.filePathFailed1440;
                gFilePathInventoryFull = Globals.filePathInventory1440;
                gFilePathEnergy = Globals.filePathEnergy1440;
            }
            else
            {
                gPointX = Globals.PointX4k;
                gPointY = Globals.PointY4k;
                gFilePathRepeat = Globals.filePathRepeat4k;
                gFilePathFailed = Globals.filePathFailed4k;
                gFilePathInventoryFull = Globals.filePathInventory4k;
                gFilePathEnergy = Globals.filePathEnergy4k;
            }

            if (gHunt)
            {
                // Run Hunt function
                while(!Globals.Cancelled)
                {
                    InventoryCheck();
                    Thread.Sleep(5000);
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
                    Thread.Sleep(5000);
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
                // Run Expedition function
                RunExpeditions();
            }
        }

        private void RunHunt()
        {
            // Looking to see if arrange is selectable or not.

            if (!ImageExistsOnScreen(gFilePathRepeat))
            {
                Console.WriteLine("We did not find the image. Battle has not ended yet.");
            }
            else
            {

                if (ImageExistsOnScreen(gFilePathFailed))
                {
                    Console.WriteLine("Finished cycle on failed. Intializing failed steps.");

                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    /*
                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        EnergyCheck();
                    }
                    */

                }
                else
                {
                    Console.WriteLine("We did find the image. Battle has ended normally.");
                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    /*
                    if (ImageExistsOnScreen(gFilePathEnergy))
                    {
                        EnergyCheck();
                    }
                    */
                }
            }
        }

        private void RunAP()
        {
            // Looking to see if arrange is selectable or not.

            if (!ImageExistsOnScreen(gFilePathRepeat))
            {
                Console.WriteLine("We did not find the image. Battle has not ended yet.");
            }
            else
            {

                if (ImageExistsOnScreen(gFilePathFailed))
                {
                    Console.WriteLine("Finished cycle on failed. Intializing failed steps.");

                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    /*
                    string filePathEnergy = "C:\\GIT Repo\\Epic7Assistant\\Epic7Assistant\\Resources\\energy1080.png";
                    if (ImageExistsOnScreen(filePathEnergy))
                    {
                        EnergyCheck();
                    }
                    */

                }
                else
                {
                    Console.WriteLine("We did find the image. Battle has ended normally.");
                    Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();
                    Thread.Sleep(gTimeBetweenClicks);
                    VirtualMouse.LeftClick();

                    /*
                    string filePathEnergy = "C:\\GIT Repo\\Epic7Assistant\\Epic7Assistant\\Resources\\energy1080.png";
                    if (ImageExistsOnScreen(filePathEnergy))
                    {
                        EnergyCheck();
                    }
                    */
                }
            }
        }

        private void RunEvent()
        {

        }

        private void RunExpeditions()
        {

        }

        private void EnergyCheck()
        {
            Cursor.Position = new System.Drawing.Point(gPointX, gPointY);
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
            Thread.Sleep(gTimeBetweenClicks);
            VirtualMouse.LeftClick();
        }

        private void InventoryCheck()
        {
            if(ImageExistsOnScreen(gFilePathInventoryFull))
            {
                Console.WriteLine("Inventory Full. Job Complete");
                return;
            }
            else
            {
                Console.WriteLine("Inventory not Full. Moving on.");
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

