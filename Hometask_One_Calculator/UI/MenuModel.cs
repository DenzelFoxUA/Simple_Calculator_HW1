using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_One_Calculator
{
    public abstract class MenuModel
    {
        public abstract string Title { get; protected set; }

        public abstract List<ButtonModel> Buttons { get; protected set; }

        public override string ToString()
        {
            string menuText = string.Empty;

            menuText += Title + "\n";
            foreach (ButtonModel button in Buttons)
            {
                menuText += button.ToString() + "\n";
            }

            return menuText;
        }

    }

    public class MenuBase:MenuModel
    {
        private MenuBase(string title, List<ButtonModel> buttons)
        {
            Title = title;
            Buttons = buttons;
        }

        public override string Title { get; protected set; }
        public override List<ButtonModel> Buttons { get; protected set; }

        public class MenuBuilder
        {
            private string _title = string.Empty;
            private List<ButtonModel> _buttonsBuilder = new List<ButtonModel>();

            public MenuModel Build()
            {
                return new MenuBase(this._title, this._buttonsBuilder);
            }

            public MenuBuilder SetTitle(string value)
            {
                if (value is not null)
                {
                    _title = value;
                    return this;
                } 
                else
                    throw new NullReferenceException("Title has null reference");
            }

            public MenuBuilder AddButton(ButtonModel buttonSet)
            {
                if (buttonSet is not null)
                {
                    _buttonsBuilder.Add(buttonSet);
                    return this;
                }
                else
                    throw new NullReferenceException("Buttons object has null reference");
            }

        }
    }

}
