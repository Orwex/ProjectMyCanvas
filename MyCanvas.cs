using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1002_MyCanvas
{
    public class MyCanvas
    {
        public const int MaxWidth = 800;
        public const int MaxHeight = 600;
        private static int buttonIndex = 0;
        private static int MaxButtons = 3;
        private static MyButton[] buttons = new MyButton[MaxButtons];

        public static bool CreateNewButton(int x1, int y1, int x2, int y2)
        {
            bool toContinue = true;
            
            //finding free button:
            if (buttonIndex < MaxButtons)
            {
                if ((x1 > 0) && (x1 <= MaxWidth) && (x2 > 0) && (x2 <= MaxWidth) &&
                    (y1 > 0) && (y1 <= MaxHeight) && (y2 > 0) && (y2 <= MaxHeight))
                {
                    if ((x1 < x2) && (y1 < y2))
                    {
                        Point NewPoint_TopLeft = new Point(x1, y1);
                        Point NewPoint_BottomRight = new Point(x2, y2);
                        buttons[buttonIndex] = new MyButton(NewPoint_TopLeft, NewPoint_BottomRight);                        
                        buttonIndex++;
                        toContinue = true;
                    }
                    else
                        Console.WriteLine("TopLeft is not in right place relativly to BottomRight");
                }
                else
                    Console.WriteLine("Button point x,y are wrong !");
            }
            else
                toContinue = false;
            return toContinue;
        }
        public static bool MoveButton(int buttonNumber, int x, int y)
        {
            int oldX, oldY;
            oldX = buttons[buttonNumber].GetBottomRight().GetX();
            oldY = buttons[buttonNumber].GetBottomRight().GetY();
            buttons[buttonNumber].SetBotomRight(new Point(oldX + x, oldY + y));
            oldX = buttons[buttonNumber].GetTopLeft().GetX();
            oldY = buttons[buttonNumber].GetTopLeft().GetY();
            buttons[buttonNumber].SetTopLeft(new Point(oldX + x, oldY + y));

            return true;
        }
        public static bool DeleteLastButton()
        {
            if (buttonIndex > 0)
            {
                buttonIndex--;                                
                return true;
            }
            else
                return false;
        }

        public static void ClearAllButtons()
        {
            if (buttonIndex > 0)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetTopLeft(new Point(0, 0));
                    buttons[i].SetBotomRight(new Point(0, 0));
                }                
                buttonIndex=0;                
            }
        }

        public static int GetCurrentNumberOfButtons()
        {
            return buttonIndex;
        }
        public static int GetMaxNumberOfButtons()
        {
            return MaxButtons;
        }
        public static int GetTheMaxWidthOfAButton()
        {
            int MaxWidthOfAButton = 0;
            if (buttonIndex > 0)
            { 
                for (int i = 0; i < buttonIndex; i++)
                {
                    if ((buttons[i].GetBottomRight().GetX() - buttons[i].GetTopLeft().GetX()) > MaxWidthOfAButton)
                        MaxWidthOfAButton = buttons[i].GetBottomRight().GetX() - buttons[i].GetTopLeft().GetX();
                }
                return MaxWidthOfAButton;
            }
            else
            {
                return 0;
            }
        }
        public static int GetTheMaxHeightOfAButton()
        {
            int MaxHightOfAButton = 0;
            if (buttonIndex > 0)
            {
                for (int i = 0; i < buttonIndex; i++)
                {
                    if ((buttons[i].GetTopLeft().GetY() - buttons[i].GetBottomRight().GetY()) > MaxHightOfAButton)
                        MaxHightOfAButton = buttons[i].GetBottomRight().GetX() - buttons[i].GetTopLeft().GetX();
                }
                return MaxHightOfAButton;
            }
            else
            {
                return 0;
            }
        }
        public static void Print(MyCanvas BluePrint)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                Console.WriteLine(buttons[i]);
            }
        }
        public static bool IsPointInsideAButton(int x, int y)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if ((buttons[i].GetTopLeft().GetX() < x) && (buttons[i].GetBottomRight().GetX() > x) && 
                    (buttons[i].GetTopLeft().GetY() < y) && (buttons[i].GetBottomRight().GetY() > y))
                    return true;
            }
            return false;
        }
        public static bool CheckIfAnyButtonIsOverlapping()
        {
            int x, y;
            for (int i = 0; i < buttons.Length; i++)
            {
                x = buttons[i].GetTopLeft().GetX();
                y = buttons[i].GetTopLeft().GetY();
                if (IsPointInsideAButton(x, y))
                    return true;

                x = buttons[i].GetBottomRight().GetX();
                y = buttons[i].GetBottomRight().GetY();
                if (IsPointInsideAButton(x, y))
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"MaxWidth {MaxWidth} MaxHeight {MaxHeight} buttonIndex {buttonIndex} MaxButtons {MaxButtons} ";
        }
        
    }
}
