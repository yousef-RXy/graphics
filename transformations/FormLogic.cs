using System.Drawing.Drawing2D;

namespace transformations;

public class FormLogic
{
    public static TrackBar trackRotation, trackTransX, trackTransY, trackScaleX, trackScaleY, trackShearX, trackShearY;
    public static PictureBox pictureBox;
    public static void ApplyTransformations()
    {
        if (pictureBox.Image == null) return;

        Bitmap original = resizeimage();
        Bitmap transformed = new Bitmap(original.Width, original.Height);

        using (Graphics g = Graphics.FromImage(transformed))
        {
            g.Clear(Color.Black);
            g.TranslateTransform(original.Width / 2, original.Height / 2);

            Matrix transform = new Matrix();

            foreach (string transformation in clickLogOrder)
            {
                switch (transformation)
                {
                    case "Rotation":
                        var deg = trackRotation.Value;
                        ApplyRotation(transform, deg);
                        break;

                    case "Translation":
                        var tx = trackTransX.Value;
                        var ty = trackTransY.Value;
                        ApplyTranslation(transform, tx, ty);
                        break;

                    case "Scale":
                        var sx = trackScaleX.Value / 100f;
                        var sy = trackScaleY.Value / 100f;
                        ApplyScaling(transform, sx, sy);
                        break;

                    case "Shear":
                        var shx = trackShearX.Value / 100.1f;
                        var shy = trackShearY.Value / 100.1f;
                        ApplyShear(transform, shx, shy);
                        break;

                    case "Reflection":
                        string axis = comboReflectBox.SelectedItem.ToString();
                        switch (axis)
                        {
                            case "Horizontal":
                                ApplyScaling(transform, 1, -1);
                                break;
                            case "Vertical":
                                ApplyScaling(transform, -1, 1);
                                break;
                            case "Both":
                                ApplyScaling(transform, -1, -1);
                                break;
                        }
                        break;
                }
            }

            g.MultiplyTransform(transform);
            g.DrawImage(
            original,
            new Rectangle(-pictureBox.Width / 2, -pictureBox.Height / 2, pictureBox.Width, pictureBox.Height)
            );
        }
        pictureBox.Image = transformed;
    }

    public static void ApplyRotation(Matrix matrix, float degrees)
    {
        float radians = degrees * (float)(Math.PI / 180);
        float cos = (float)Math.Cos(radians);
        float sin = (float)Math.Sin(radians);

        Matrix rotation = new Matrix(
            cos, sin,
           -sin, cos,
            0, 0
        );

        matrix.Multiply(rotation, MatrixOrder.Prepend);
    }

    public static void ApplyTranslation(Matrix matrix, float dx, float dy)
    {
        Matrix translation = new Matrix(
            1, 0,
            0, 1,
            dx, dy
        );

        matrix.Multiply(translation, MatrixOrder.Prepend);
    }

    public static void ApplyScaling(Matrix matrix, float sx, float sy)
    {
        Matrix scaling = new Matrix(
            sx, 0,
            0, sy,
            0, 0
        );

        matrix.Multiply(scaling, MatrixOrder.Prepend);
    }

    public static void ApplyShear(Matrix matrix, float shx, float shy)
    {
        Matrix shear = new Matrix(
            1, shy,
            shx, 1,
            0, 0
        );

        matrix.Multiply(shear, MatrixOrder.Prepend);
    }
    public static Bitmap resizeimage()
    {
        Image originalImage = Image.FromFile(@"E:\Projects\programing-projects\c#\graphics\transformations\Metal Box.png");

        int scalePercent = 80;
        int newWidth = originalImage.Width * scalePercent / 100;
        int newHeight = originalImage.Height * scalePercent / 100;
        return new Bitmap(originalImage, new Size(newWidth, newHeight));
    }
}
