/**
  ******************************************************************************
  * @file    TouchScreen\TouchScreen\Program.cs
  * @author  MCD
  * @version V1.0.0
  * @date    24-Sep-2013
  * @brief   Main program body
  ******************************************************************************
   * @attention
  *
  * <h2><center>&copy; COPYRIGHT 2013 STMicroelectronics</center></h2>
  *
  * Licensed under MCD-ST Liberty SW License Agreement V2, (the "License");
  * You may not use this file except in compliance with the License.
  * You may obtain a copy of the License at:
  *
  *        http://www.st.com/software_license_agreement_liberty_v2
  *
  * Unless required by applicable law or agreed to in writing, software 
  * distributed under the License is distributed on an "AS IS" BASIS, 
  * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
  * See the License for the specific language governing permissions and
  * limitations under the License.
  *
  * <h2><center>&copy; COPYRIGHT 2013 STMicroelectronics</center></h2>
  */

/* References ------------------------------------------------------------------*/
using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Input;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Hardware;
using STM32F429I_Discovery.Netmf.Hardware;


namespace TouchScreenExample
{
    /// <summary>
    /// Touch screen example.
    /// </summary>
    public class MyTouchScreen : Microsoft.SPOT.Application
    {
        /// <summary>
        /// Main window
        /// </summary>
        /// 
        static int resolution = 270;
        static int offset = 0; // zminna do wysokoœci przebiegu
        static double scale = 1; //zmienna do skali przebiegu

        static double[] values = new double[resolution];
        static double[] valuesStopped = new double[resolution];
        static int samplingIndex = 0;
        static bool isStopped = false;


        public class MainWindow : Window
        {
            SolidColorBrush brush = new SolidColorBrush(Color.Black);
            //Text text1 = new Text();
            //Text text2 = new Text();
            Panel panel = new Panel();


            public MainWindow()
            {
                //text1.TextContent = "    Touch screen   ";
                //text1.TextWrap = true;
                //text1.Font = Resources.GetFont(Resources.FontResources.small);
                //text1.HorizontalAlignment = HorizontalAlignment.Center;
                //text1.VerticalAlignment = VerticalAlignment.Top;

                //text2.TextContent = "    Click Anywhere   ";
                //text2.TextWrap = true;
                //text2.Font = Resources.GetFont(Resources.FontResources.small);
                //text2.HorizontalAlignment = HorizontalAlignment.Center;
                //text2.VerticalAlignment = VerticalAlignment.Bottom;

                /* Add text control to the main window.*/
                this.Child = panel;
                //panel.Children.Add(text1);
                //panel.Children.Add(text2);

            }

            int cx = 0;
            int cy = 0;


            /// <summary>
            /// Handles the touch down event.
            /// </summary>
            /// <param name="e"></param>
            protected override void OnTouchDown(TouchEventArgs e)
            {
                base.OnTouchDown(e);
                
                int x;
                int y;

                /* Get touch position */
                e.GetPosition((UIElement)this, 0, out x, out y);

                cx = x;
                cy = y;

                int buttonCount = 0;
                int buttonHeight = 34;

                if (y > 270 && x > buttonCount++  *buttonHeight && x < buttonCount * buttonHeight)
                {
                    offset -= 5;
                }

                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                    offset += 5;
                }

                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                    scale -= 0.05;
                }

                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                    scale += 0.05;
                }



                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                }


                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                }



                if (y > 270 && x > buttonCount++ * buttonHeight && x < buttonCount * buttonHeight)
                {
                    isStopped = !isStopped;

                    if (isStopped)
                    {
                        for (int i = 0; i < resolution; i++)
                        {
                            valuesStopped[i] = values[i];
                        }
                    }
                }



                //text1.TextContent = "Channel0 (pin 6 ) = " + (values[samplingIndex++]  * 3.3).ToString("f2") + "V";

                //this.Invalidate();

                panel.Invalidate();
                e.Handled = true;

            }

          
            /// <summary>
            /// Handles the render event.
            /// </summary>
            /// <param name="dc"></param>
            public override void OnRender(DrawingContext dc)
            {
                base.OnRender(dc);

                dc.DrawRectangle(new SolidColorBrush(Colors.Black), new Pen(Colors.White), 0, 0, 200, 270);

                int buttonCount = 0;
                int buttonHeight = 34;

                dc.DrawRectangle(new SolidColorBrush(Colors.Red), new Pen(Colors.Red), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);
                dc.DrawRectangle(new SolidColorBrush(Colors.Green), new Pen(Colors.Green), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);

                dc.DrawRectangle(new SolidColorBrush(Colors.Red), new Pen(Colors.Red), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);
                dc.DrawRectangle(new SolidColorBrush(Colors.Green), new Pen(Colors.Green), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);

                dc.DrawRectangle(new SolidColorBrush(Colors.Red), new Pen(Colors.Red), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);
                dc.DrawRectangle(new SolidColorBrush(Colors.Green), new Pen(Colors.Green), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);

                dc.DrawRectangle(new SolidColorBrush(Colors.Yellow), new Pen(Colors.Yellow), buttonCount++ * buttonHeight, 270, buttonCount * buttonHeight, 320);

                dc.DrawLine(new Pen(Colors.Gray), 50, 0, 50, 270);
                dc.DrawLine(new Pen(Colors.Gray), 150, 0, 150, 270);

                dc.DrawLine(new Pen(Colors.Gray), 0, 67, 200, 67);
                dc.DrawLine(new Pen(Colors.Gray), 0, 202, 200, 202);


                dc.DrawLine(new Pen(Colors.LightGray), 100, 0, 100, 270);
                dc.DrawLine(new Pen(Colors.LightGray), 0, 135, 200, 135);

                for (int i = 0; i < resolution-1; i++)
                {
                    int value = 0;
                    int valueNext = 0;

                    if (!isStopped)
                    {
                        value = (int)((values[i] / 20.53) * scale); //skalowanie przebigu
                        valueNext = (int)((values[i+1] / 20.53) * scale); //skalowanie przebigu
                    } else {
                        value = (int)((valuesStopped[i] / 20.53) * scale); //skalowanie przebigu
                        valueNext = (int)((valuesStopped[i+1] / 20.53) * scale); //skalowanie przebigu
                    }

                    dc.DrawLine(new Pen(Colors.Yellow), value + 1 + offset, i, valueNext + 1 + offset, i);  

                }

                dc.DrawRectangle(new SolidColorBrush(Colors.LightGray), new Pen(Colors.LightGray), 200, 0, 240, 270);
            }
        }

        public class ADCReader
        {
            private AnalogInput ADC0 = new AnalogInput(ADC.Channel0_PA6);

            public void readADCandUpdate()
            {
                while (true)
                {
                    double adcValue = ADC0.ReadRaw();

                    if (samplingIndex >= resolution)
                        samplingIndex = 0;

                    values[samplingIndex++] = adcValue;
                }
            }
        }

        public static MyTouchScreen myApplication;

        /// <summary>
        /// Main function(entry point).
        /// </summary>
        public static void Main()
        {
            myApplication = new MyTouchScreen();
            /* Enable Touch engine */
            Microsoft.SPOT.Touch.Touch.Initialize(myApplication);
            /* Create window object */
            Window mainWindow = myApplication.CreateWindow();

            ADCReader adcReader = new ADCReader();
            Thread oThread = new Thread(adcReader.readADCandUpdate);
            oThread.Start();


            /* Start the application */
            myApplication.Run(mainWindow);
        }

        public MainWindow mainWindow;

        /// <summary>
        /// Create window object with button focus.
        /// </summary>
        /// <returns></returns>
        public Window CreateWindow()
        {
            /* Create window object */
            mainWindow = new MainWindow();
            mainWindow.Height = SystemMetrics.ScreenHeight;
            mainWindow.Width = SystemMetrics.ScreenWidth;
            mainWindow.Visibility = Visibility.Visible;
            Buttons.Focus(mainWindow);

            return mainWindow;
        }

      
    }

    
}
/******************* (C) COPYRIGHT STMicroelectronics *****END OF FILE****/