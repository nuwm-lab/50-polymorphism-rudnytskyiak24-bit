using System;

namespace GeometryFigures
{
    /// <summary>
    /// Базовий клас "Коло в просторі"
    /// </summary>
    class KoloVPryostori
    {
        protected double X { get; set; }
        protected double Y { get; set; }
        protected double Z { get; set; }
        protected double Radius { get; set; }

        // Допоміжний метод для запиту числових даних
        protected double ZapytatyChyslo(string zapytannya)
        {
            Console.WriteLine(zapytannya);
            while (!double.TryParse(Console.ReadLine(), out double result))
            {
                Console.WriteLine("Невірний формат. Спробуйте ще раз:");
            }
            return result;
        }

        public virtual void ZadatyDani()
        {
            X = ZapytatyChyslo("Введіть координату X центра кола:");
            Y = ZapytatyChyslo("Введіть координату Y центра кола:");
            Z = ZapytatyChyslo("Введіть координату Z центра кола:");
            Radius = ZapytatyChyslo("Введіть радіус кола:");
        }

        public virtual void VivestyDani()
        {
            Console.WriteLine($"Центр кола: ({X}, {Y}, {Z}), Радіус: {Radius}");
        }

        public virtual double DovzhynaKola()
        {
            return 2 * Math.PI * Radius;
        }
    }

    /// <summary>
    /// Похідний клас "Конус"
    /// </summary>
    class Konus : KoloVPryostori
    {
        private double VertexX { get; set; }
        private double VertexY { get; set; }
        private double VertexZ { get; set; }
        private double Tvyrna { get; set; }

        public override void ZadatyDani()
        {
            // Вводимо координати вершини
            VertexX = ZapytatyChyslo("Введіть координату X вершини конуса:");
            VertexY = ZapytatyChyslo("Введіть координату Y вершини конуса:");
            VertexZ = ZapytatyChyslo("Введіть координату Z вершини конуса:");
            Tvyrna = ZapytatyChyslo("Введіть довжину твірної конуса:");

            // Викликаємо базовий метод для центру кола і радіуса
            base.ZadatyDani();
        }

        public override void VivestyDani()
        {
            Console.WriteLine($"Вершина: ({VertexX}, {VertexY}, {VertexZ}), Твірна: {Tvyrna}");
            base.VivestyDani();
        }

        public double BichnaPoverkhnia()
        {
            return Math.PI * Radius * Tvyrna;
        }

        public double RadiusOsnovy()
        {
            return Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            KoloVPryostori figura;
            Console.WriteLine("Виберіть тип фігури (1 - Коло в просторі, 2 - Конус):");
            string choice = Console.ReadLine();

            if (choice == "2")
                figura = new Konus();
            else
                figura = new KoloVPryostori();

            figura.ZadatyDani();
            figura.VivestyDani();

            Console.WriteLine($"Довжина кола: {figura.DovzhynaKola():F2}");

            if (figura is Konus konus)
            {
                Console.WriteLine($"Радіус основи конуса: {konus.RadiusOsnovy():F2}");
                Console.WriteLine($"Бічна поверхня конуса: {konus.BichnaPoverkhnia():F2}");
            }
        }
    }
}

