using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Drawing
{
    public struct Size : IEquatable<Size>
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Size(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// Compares the width and height properties.
        /// </summary>
        /// <param name="obj">Size object to compare.</param>
        /// <returns>Comparation result.</returns>
        public override bool Equals(object obj)
        {
            Size comparationSize = (Size)obj;

            return this.Width == comparationSize.Width && this.Height == comparationSize.Height;
        }

        /// <summary>
        /// Returns the hash code of this instance.
        /// </summary>
        /// <returns>Hach code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns this instance values string formatted.
        /// </summary>
        /// <returns>Formatted values.</returns>
        public override string ToString()
        {
            return String.Format("Width: {0}, Height: {1}", this.Width, this.Height);
        }

        /// <summary>
        /// Compares the width and height properties.
        /// </summary>
        /// <param name="other">Size object to compare.</param>
        /// <returns>Comparation result.</returns>
        public bool Equals(Size other)
        {
            return this.Width == other.Width && this.Height == other.Height;
        }
    }
}
