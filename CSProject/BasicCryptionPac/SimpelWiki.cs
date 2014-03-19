using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Steganograph.PlugIns;

namespace BasicCryptionPac
{
    class SimpelWiki : CryptImgPlugIn //HACK: ToDO: short in int (performance)
    {
        /// <summary>
        /// the name of this plugin
        /// </summary>
        public string Name
        {
            get { return "Simpel (Wikipedia)"; }
        }

        /// <summary>
        /// writes a message into a bitmap
        /// </summary>
        /// <param name="OriginalImage">the original bitmap</param>
        /// <returns>the modified bitmap</returns>
        public Bitmap EncryptImg(Bitmap OriginalImage)
        {
            InAndOutPut inandout = new InAndOutPut();
            string Passwort = "";
            if (inandout.ShowDialog(false, true, "Geben Sie ein Passwort ein.", this.Name) == System.Windows.Forms.DialogResult.OK)
            {
                Passwort = inandout.StrText.ToUpper();
                if (string.IsNullOrEmpty(Passwort) || string.IsNullOrWhiteSpace(Passwort))
                {
                    System.Windows.Forms.MessageBox.Show("Das Passwort darf nicht leer sein.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
                else if (!onlyContainsAlphabet(Passwort))
                {
                    System.Windows.Forms.MessageBox.Show("Es sind nur Zeichen aus dem Alphabet erlaubt.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
            }
            else
            {
                return null;
            }
            string Message = "";
            if (inandout.ShowDialog(false, false, "Geben Sie eine Nachricht ein, die verschlüsselt werden soll.", this.Name) == System.Windows.Forms.DialogResult.OK)
            {
                Message = inandout.StrText.ToUpper();
                if (string.IsNullOrEmpty(Message) || string.IsNullOrWhiteSpace(Message))
                {
                    System.Windows.Forms.MessageBox.Show("Die Nachricht darf nicht leer sein.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
                else if (!onlyContainsAlphabet(Message))
                {
                    System.Windows.Forms.MessageBox.Show("Es sind nur Zeichen aus dem Alphabet erlaubt.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
            }
            else
            {
                return null;
            }
            //start encrytion
            
            //Passwortbuchstaben Zahlen ermitteln
            List<short> pwShrt = new List<short>();
            foreach (char c in Passwort)
            {
                short shrt = getNumberFromChar(c);
                if (!pwShrt.Contains<short>(shrt))
                {
                    pwShrt.Add(shrt);
                }
            }
            pwShrt.Sort(); //der größe nach Sortieren

            //Message-buchstaben Zahlenwerte ermitteln
            List<short> mesShrt = new List<short>();
            foreach (char c in Message)
            {
                mesShrt.Add(getNumberFromChar(c));
            }

            if (!imageLargeEnoughToEncrypt(OriginalImage, pwShrt.Count, mesShrt.Count))
            {
                System.Windows.Forms.MessageBox.Show("Das Bild ist zu klein, um die Nachricht mit dem benutzten Passwort zu verschlüsseln. Verwenden Sie ein größeres Bild, eine kleiner Nachricht oder ein Passwort mit mehreren verschiedenen Zeichen.",
                    "Konnte nicht verschlüsseln", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
            
            //Nachricht einbauen, bis die Nachricht vollständig verbraten ist
            long currentrnd = 0; //Die Anzahl der durchgänge durch das Passwort
            short currentPWindex = -1; //Der Index des aktuellen Passwortzeichens
            do
            {
                long currentnr; //aktueller Pixel
                if (pwShrt.Count > (currentPWindex + 1)) //richtige Stelle für das nächste Zeichen anhand des Passwortes ermitteln
                {
                    currentPWindex++;
                }
                else
                {
                    currentrnd++;
                    currentPWindex = 0;
                }
                currentnr = (currentrnd * 26) + pwShrt[currentPWindex];

                setCharToPixel(currentnr, mesShrt[0], OriginalImage); //Numerischen Wert des ersten Zeichens der Meldung ins Bild an die richtige Stelle einbauen

                mesShrt.RemoveAt(0); //erstes Zeichen der Message entfernen, da es schon eingebaut wurde
            } while (mesShrt.Count > 0);

            //for (int i = 0; i < OriginalImage.Width * OriginalImage.Height; i++)
            //{
            //    setCharToPixel(i, mesShrt[0], OriginalImage);
            //}


            return OriginalImage;
        }

        public Bitmap DecryptImg(Bitmap CryptedImage)
        {

            InAndOutPut inandout = new InAndOutPut();
            string Passwort = "";
            if (inandout.ShowDialog(false, true, "Geben Sie ein Passwort ein.", this.Name) == System.Windows.Forms.DialogResult.OK)
            {
                Passwort = inandout.StrText.ToUpper();
                if (string.IsNullOrEmpty(Passwort) || string.IsNullOrWhiteSpace(Passwort))
                {
                    System.Windows.Forms.MessageBox.Show("Das Passwort darf nicht leer sein.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
                else if (!onlyContainsAlphabet(Passwort))
                {
                    System.Windows.Forms.MessageBox.Show("Es sind nur Zeichen aus dem Alphabet erlaubt.", "Ungültige Eingabe", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    return null;
                }
            }
            else
            {
                return null;
            }
            //start decrytion

            //Passwortbuchstaben Zahlen ermitteln
            List<short> pwShrt = new List<short>();
            foreach (char c in Passwort)
            {
                short shrt = getNumberFromChar(c);
                if (!pwShrt.Contains<short>(shrt))
                {
                    pwShrt.Add(shrt);
                }
            }
            pwShrt.Sort(); //der größe nach Sortieren

            //Plausibilität ermitteln, ob das Bild eine Botschaft passend zum Passwort enthalten kann.
            if (!imageLargeEnoughToDecrypt(CryptedImage, pwShrt))
            {
                System.Windows.Forms.MessageBox.Show("Das Bild ist zu klein, als dass es eine Nachricht mit diesem Passwort enthalten kann. Vielleicht ist das Passwort falsch, oder das Bild enthält keine Nachricht.",
                    "Konnte nicht entschlüsseln", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }

            //Nachricht auslesen, bis ungültige Zeichen gefunden werden
            List<int> mesShrt = new List<int>();
            long imgLength = CryptedImage.Width * CryptedImage.Height;
            long currentrnd = 0; //Die Anzahl der durchgänge durch das Passwort
            short currentPWindex = -1; //Der Index des aktuellen Passwortzeichens
            bool goOn = true; //weitermachen bis false
            do
            {
                long currentnr; //aktueller Pixel
                if (pwShrt.Count > (currentPWindex + 1)) //richtige Stelle für das nächste Zeichen anhand des Passwortes ermitteln
                {
                    currentPWindex++;
                }
                else
                {
                    currentrnd++;
                    currentPWindex = 0;
                }
                currentnr = (currentrnd * 26) + pwShrt[currentPWindex];

                if (currentnr < imgLength)
                {
                    int nShrt = getCharFromPixel(currentnr, CryptedImage); //Numerischen Wert aus dem Pixel auslesen

                    if (nShrt <= 26 && nShrt > 0)
                    {
                        mesShrt.Add(nShrt); //Buchstaben ins Array der gefundenen hinzufügen
                    }
                    else
                    {
                        goOn = false; //wenn ein Wert über 26 dann hat die Message (wharscheinlich) schon aufgehört
                    }
                }
                else
                {
                    goOn = false; //Ende vom Bild
                }
            } while (goOn);

            string Message = "";
            foreach (short shrt in mesShrt)
            {
                Message += getCharFromNumber(shrt);
            }

            if (Message == "")
            {
                System.Windows.Forms.MessageBox.Show("Es konnte keine Nachricht aus dem Bild gelesen werden. Entweder ist das Passwort falsch, oder das Bild enthält keine Nachricht. (Mehr Information: Schon der erste untersuchte Pixel enthielt keine gültige Information)",
                    "Keine Nachricht erkannt", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return null;
            }
            else
            {
                inandout.StrText = Message; //Ausgabe
                inandout.ShowDialog(true, false, "Folgende Nachricht konnte gefunden werden." + Environment.NewLine + "Information:" + Environment.NewLine + 
                    "Das Originalbild kann mit diesem Verfahren nicht wieder hergestellt werden. Es ist das gleiche, wie das Bild mit der Nachricht." + Environment.NewLine +
                    "Das Ende der Nachricht ist zufällig und kann auch nicht mehr Element der eigentlichen Nachricht sein.", this.Name);
            }

            return CryptedImage; //unverändert
        }

        #region tools

        /// <summary>
        /// Checks, if the string only contains chars out of the alphabeth
        /// </summary>
        /// <param name="StrTxt">the string to analize</param>
        /// <returns>true, if only chars out of the alphabeth are used</returns>
        private static bool onlyContainsAlphabet(string StrTxt)
        {
            StrTxt = StrTxt.Replace("A", "");
            StrTxt = StrTxt.Replace("B", "");
            StrTxt = StrTxt.Replace("C", "");
            StrTxt = StrTxt.Replace("D", "");
            StrTxt = StrTxt.Replace("E", "");
            StrTxt = StrTxt.Replace("F", "");
            StrTxt = StrTxt.Replace("G", "");
            StrTxt = StrTxt.Replace("H", "");
            StrTxt = StrTxt.Replace("I", "");
            StrTxt = StrTxt.Replace("J", "");
            StrTxt = StrTxt.Replace("K", "");
            StrTxt = StrTxt.Replace("L", "");
            StrTxt = StrTxt.Replace("M", "");
            StrTxt = StrTxt.Replace("N", "");
            StrTxt = StrTxt.Replace("O", "");
            StrTxt = StrTxt.Replace("P", "");
            StrTxt = StrTxt.Replace("Q", "");
            StrTxt = StrTxt.Replace("R", "");
            StrTxt = StrTxt.Replace("S", "");
            StrTxt = StrTxt.Replace("T", "");
            StrTxt = StrTxt.Replace("U", "");
            StrTxt = StrTxt.Replace("V", "");
            StrTxt = StrTxt.Replace("W", "");
            StrTxt = StrTxt.Replace("X", "");
            StrTxt = StrTxt.Replace("Y", "");
            StrTxt = StrTxt.Replace("Z", "");

            return (StrTxt == "");
        }

        /// <summary>
        /// Checks, if the image has enough pixel
        /// </summary>
        /// <param name="img">the image, that is analysed</param>
        /// <param name="pwCount">the count of different passwort chars</param>
        /// <param name="mesCount">the count of the message chars</param>
        /// <returns>true, if it is large enough</returns>
        private static bool imageLargeEnoughToEncrypt(Bitmap img, int pwCount, int mesCount)
        {
            long length = img.Width * img.Height;
            int needed = (int) (mesCount / pwCount) * 26;
            return (length >= needed);
        }

        /// <summary>
        /// Checks if the image is large enough to cover a message with this password
        /// </summary>
        /// <param name="img">the bitmap with the message</param>
        /// <param name="pwShrt">the numeric values of the password. HAVE TO BE SORTED WITH THE LARGEST LETTER-VALUE ON THE END!</param>
        /// <returns>true, if a message can be covered by this password</returns>
        private static bool imageLargeEnoughToDecrypt(Bitmap img, List<short> pwShrt)
        {
            return (img.Height > 1 || (img.Width >= pwShrt[pwShrt.Count - 1])); //true, außer Höhe == 1 und Breite ist kleiner als der größte Zahlenwert des Buchstaben des Passworts
        }

        /// <summary>
        /// Calculates the numeric value of a char
        /// </summary>
        /// <param name="chr">a char out of the alphabeth</param>
        /// <returns>the numeric value to the char chr</returns>
        private static short getNumberFromChar(char chr)
        {
            switch (chr)
            {
                case 'A': return 1;
                case 'B': return 2;
                case 'C': return 3;
                case 'D': return 4;
                case 'E': return 5;
                case 'F': return 6;
                case 'G': return 7;
                case 'H': return 8;
                case 'I': return 9;
                case 'J': return 10;
                case 'K': return 11;
                case 'L': return 12;
                case 'M': return 13;
                case 'N': return 14;
                case 'O': return 15;
                case 'P': return 16;
                case 'Q': return 17;
                case 'R': return 18;
                case 'S': return 19;
                case 'T': return 20;
                case 'U': return 21;
                case 'V': return 22;
                case 'W': return 23;
                case 'X': return 24;
                case 'Y': return 25;
                case 'Z': return 26;

                default:
                    throw new ArgumentException("Only characters out of the ABC are allowed.", "chr", null);
            }
        }

        /// <summary>
        /// Calculates the char to the numeric value of a char
        /// </summary>
        /// <param name="shrt">the numeric value</param>
        /// <returns>the chart to the numeric value</returns>
        private static char getCharFromNumber(short shrt)
        {
            switch (shrt)
            {
                case 1: return 'A';
                case 2: return 'B';
                case 3: return 'C';
                case 4: return 'D';
                case 5: return 'E';
                case 6: return 'F';
                case 7: return 'G';
                case 8: return 'H';
                case 9: return 'I';
                case 10: return 'J';
                case 11: return 'K';
                case 12: return 'L';
                case 13: return 'M';
                case 14: return 'N';
                case 15: return 'O';
                case 16: return 'P';
                case 17: return 'Q';
                case 18: return 'R';
                case 19: return 'S';
                case 20: return 'T';
                case 21: return 'U';
                case 22: return 'V';
                case 23: return 'W';
                case 24: return 'X';
                case 25: return 'Y';
                case 26: return 'Z';

                default:
                    throw new ArgumentException("Only values from 1 to 26 are allowed.", "shrt", null);
            }
        }

        /// <summary>
        /// Sets the numeric value of a char to a pixel in an image
        /// </summary>
        /// <param name="pixelnr">the number of the pixel</param>
        /// <param name="chr">the numeric value of a char</param>
        /// <param name="img">the bitmap, that schould be modified</param>
        private static void setCharToPixel(long pixelnr, short chr, Bitmap img) //HACK TODO: eig. rgb wert [0-767]
        {
            int x = (int)(pixelnr % img.Width);
            int y = (int)(pixelnr / img.Width);

            Color pixel = img.GetPixel(x, y);//.ToArgb(); und int

            int b = ((int)(pixel.B / 100)) * 100;
            b += chr;

            Color nCol = Color.FromArgb(pixel.R, pixel.G, b);
            img.SetPixel(x, y, nCol);

            //setPixelNr(pixelnr, modifyPixel(chr, getPixelNr(pixelnr, img)), img);
        }

        /// <summary>
        /// Gets the numeric value of a char from a pixel in an image
        /// </summary>
        /// <param name="pixelnr">the number of the pixel</param>
        /// <param name="img">the bitmap, with the message</param>
        /// <returns>the numeric value of a char</returns>
        private static int getCharFromPixel(long pixelnr, Bitmap img)//HACK TODO: eig. rgb wert [0-767]
        {
            int x = (int)(pixelnr % img.Width);
            int y = (int)(pixelnr / img.Width);

            Color pixel = img.GetPixel(x, y);//.ToArgb();

            int b = ((int)(pixel.B / 100)) * 100; //Bild kann nicht wiederhergestellt werden, deswegen wird es so gelassen (kein setPixel)
            int chr = pixel.B - b; //eig short, außer dieser Pixel enthält keine Info
            return chr;
        }

        ///// <summary>
        ///// Inserts a char into the color-value of a pixel
        ///// </summary>
        ///// <param name="chr">the numeric value of a char [0 - 26] (also possible:[0 - 99])</param>
        ///// <param name="pixel">the color value of a pixel [0 - 767] (also possible > 99)</param>
        ///// <returns>the modified numeric value of the pixel</returns>
        //private static int modifyPixel(short chr, int pixel)
        //{
        //    pixel = ((int)(pixel / 100)) * 100;
        //    pixel += chr;
        //    return pixel;
        //}

        ///// <summary>
        ///// Returns the ARGB-value of the pixel nr in image img
        ///// </summary>
        ///// <param name="nr">the number of the pixel</param>
        ///// <param name="img">the bitmap</param>
        ///// <returns>the argb-value</returns>
        //private static int getPixelNr(long nr, Bitmap img)
        //{
        //    int x = (int)(nr % img.Width);
        //    int y = (int)(nr / img.Width);
        //    return img.GetPixel(x, y).ToArgb();
        //}

        ///// <summary>
        ///// Sets a pixel of an image
        ///// </summary>
        ///// <param name="nr">the number of the pixel (0: left upper corner, maximum: right down corner)</param>
        ///// <param name="nPixel">the argb value of the modified pixel</param>
        ///// <param name="img">the bitmap, that should be modified</param>
        //private static void setPixelNr(long nr, int nPixel, Bitmap img)
        //{
        //    int x = (int)(nr % img.Width);
        //    int y = (int)(nr / img.Width);
        //    Color nCol = Color.FromArgb(nPixel);
        //    img.SetPixel(x, y, nCol);
        //}

        #endregion tools
    }
}
