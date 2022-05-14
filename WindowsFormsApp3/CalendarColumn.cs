namespace WindowsFormsApp3
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

public class CalendarColumn : DataGridViewColumn, IColorFormat
{

    public IList<ColorFormat> ColorFormats { get; set; }

    public CalendarColumn() : base(new CalendarCell())
    {
    }

    public override DataGridViewCell CellTemplate
    {
        get
        {
            return base.CellTemplate;
        }
        set
        {
                // Убедитесь, что ячейка, используемая для шаблона, является ячейкой календаря.
                if (value != null &&
                !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
            {
                throw new InvalidCastException("Must be a CalendarCell");
            }
            base.CellTemplate = value;
        }
    }
}



    public class CalendarColumn1 : DataGridViewColumn, IColorFormat1
    {

        public IList<ColorFormat1> ColorFormats1 { get; set; }

        public CalendarColumn1() : base(new CalendarCell1())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                //// Убедитесь, что ячейка, используемая для шаблона, является ячейкой календаря.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell1)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}