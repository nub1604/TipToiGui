using System.ComponentModel;
using System.Drawing;

namespace TipToyGui
{
    /// <summary>
    /// 
    /// </summary>
    public struct TTToolSettings
    {
      
        /// <summary>
        /// Die Option --dpi gibt die gewünschte Auflösung des Musters an, in der im Druck üblichen Einheit Punkt-ProZoll (dots per inch). 
        /// Der Standardwert ist 1200 DPI, unter Umständen genügen auch 600 DPI.
        /// </summary>
        public int DPI { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public EnumImageFormat ImageFormat { get; set; }
        /// <summary>
        /// • Mit der Option --code-dim legst du fest, wie groß das Muster erzeugt werden soll. Du kannst entweder
        ///eine Zahl angeben, dann bekommst du ein Quadrat mit der angegebenen Seitenlänge in Millimeter, also
        ///--code-dim 30 für ein 3×3cm Quadrat(dies ist die Standard-Einstellung). Oder du gibst mit zwei Zahlen
        ///die Breite und Höhe an, etwa -code-dim 210x297 für ein Muster in A4-Größe.
        /// </summary>
        public Size CodeDim {get; set;}
        /// <summary>
        /// Die Option --pixel-size gibt an aus wievielen Pixel (im Quadrat) ein Punkt des Musters gebaut werden
        ///soll.Der Standardwert ist 2. Wenn du diese Zahl erhöhst bekommst du ein kräftigeres, schwärzeres Muster, das
        ///zwar stärker auffällt, aber vielleicht besser erkannt wird.
        ///
        /// </summary>
        public int PixelSize { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
     [DefaultValue(EnumDPI.High)]
    public enum EnumDPI
    { 
        // 47,24  x 47,24 Pixel Pro OidCode 
        High = 1200,
        // 24x24 Pixel pro OID Code
        Low = 600

       
    }
    public enum EnumImageFormat
    {
        Default,
        /// <summary>
        ///  PNG (mittels --image-format PNG) ist ein pixelbasiertes Bildformat. Es eignet sich gut wenn du dein
        ///Projekt mit einem Bildverarbeitungsprogramm wie GIMP oder Photoshop erzeugst. Achte darauf dass du das
        ///Bild nach dem Import in dein Programm nicht skalierst oder drehst, sondern allenfalls zuschneidest. PNG ist das
        ///Standardformat für tttool oid-code und tttool oid-codes, und wird von tttool oid-table nicht unterstützt.
        /// </summary>
        PNG,
        /// <summary>
        /// PDF (mittels --image-format PDF) wird nur von tttool oid-table unterstützt und ist dort
        ///auch die Standardeinstellung, und eignet sich gut zum Drucken der Tabelle, jedoch nur bedingt für die Weiterverarbeitung.
        /// </summary>
        PDF,
        /// <summary>
        /// SVG (mittels --image-format SVG) ist ein Vektor-Format, und eigentlich sich gut für die
        /// Weiterverarbeitung in Zeichenprogrammen wie Inkscape oder Illustrator. So kann man zum Beispiel mit
        /// tttool --image-format SVG oid-table eine SVG-Datei mit allen Mustern erzeugen, und diese
        /// dann weiterverarbeiten. SVG wird von allen Befehlen unterstützt.
        /// </summary>
        SVG,
        /// <summary>
        /// SVG mit PNG (mittels --image-format SVG+PNG) ist eine Variante, bei der zwar als SVG-Dateien
        /// erzeugen werden, aber in der SVG-Datei das Muster selbst als PNG-Datei angelegt ist. Dies kann, je nach
        /// verwendetem Programm und Drucker, eventuell zu besser erkennbaren Mustern führen.
        /// </summary>
        SVGPNG

    }
}
