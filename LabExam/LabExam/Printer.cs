using System;
using System.Collections.Generic;
using System.IO;

namespace LabExam
{
    public abstract class Printer : IPrinter, IEquatable<Printer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Printer"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="ArgumentNullException">Model is empty!</exception>
        protected Printer(string model)
        {
            if (String.IsNullOrWhiteSpace(model))
            {
                throw new ArgumentNullException("Model is empty!");
            }

            this.Model = model;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name { get ;}

        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model { get;}

        /// <summary>
        /// Occurs when [start print].
        /// </summary>
        public event EventHandler<PrintEventArgs> StartPrint = delegate { };

        /// <summary>
        /// Occurs when [end print].
        /// </summary>
        public event EventHandler<PrintEventArgs> EndPrint = delegate { };

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.Equals((Printer)obj);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Printer other)
        {
            if(ReferenceEquals(other,null))
            {
                return false;
            }

            if(ReferenceEquals(this,other))
            {
                return true;
            }

            if(Name == other.Name && Model == other.Model)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"{Name} {Model}";
        }

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="stream"></param>
        public void Print(Stream stream) 
        {
            OnStartPrint(new PrintEventArgs(this));
            PrintRule(stream);
            OnEndPrint(new PrintEventArgs(this));
            
        }

        /// <summary>
        /// Print.
        /// </summary>
        /// <param name="stream">The stream.</param>
        protected abstract void PrintRule(Stream stream);

        /// <summary>
        /// Prints the specified file stream.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        void IPrinter.Print(Stream stream)
        {
            this.Print(stream);
        }

        /// <summary>
        /// Raises the <see cref="E:StartPrint" /> event.
        /// </summary>
        /// <param name="args">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnStartPrint(PrintEventArgs args)
        {
            StartPrint.Invoke(this, args);
        }

        /// <summary>
        /// Raises the <see cref="E:EndPrint" /> event.
        /// </summary>
        /// <param name="args">The <see cref="PrintEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEndPrint(PrintEventArgs args)
        {
            EndPrint.Invoke(this, args);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var hashCode = -1566092560;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Model);
            return hashCode;
        }
    }
}