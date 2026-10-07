using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
namespace Lab_3
{
    public class CClickSpeedUp : CCollectable
    {
        private double speedModifier;


        public override bool onClick(CPlayer player, CController controller,Point mousePosition)
        {
            if (isMouseOnObject(mousePosition) == false)
                return false;
            controller.pointsIncrease(pointsValue);
                return true;
        }
    }
}
