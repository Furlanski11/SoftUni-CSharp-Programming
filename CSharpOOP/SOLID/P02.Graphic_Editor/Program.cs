namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape square = new Square();
            IShape circle = new Circle();
            IShape rectangle = new Rectangle();
            IShape cube = new Cube();
            GraphicEditor editor = new GraphicEditor();
            editor.DrawShape(square);
            editor.DrawShape(circle);
            editor.DrawShape(rectangle);
            editor.DrawShape(cube);
        }
    }
}
