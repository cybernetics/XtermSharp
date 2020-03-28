﻿using System;

namespace XtermSharp {
	// MIGUEL TODO:
    	// The original code used Rune + Code, but it really makes no sense to keep those separate, excpt for null that has a
	// zero-width thing for code 0.
	public struct CharData {
		public int Attribute;
		public Rune Rune;
		public int Width;
		public int Code;

		// ((int)flags << 18) | (fg << 9) | bg;

		public const int DefaultAttr = Renderer.DefaultColor << 9 | (256 << 0);
		public const int InvertedAttr = Renderer.InvertedDefaultColor << 9 | (256 << 0) | Renderer.InvertedDefaultColor;

		public static CharData Null = new CharData (DefaultAttr, '\u0200', 1, 0);
		public static CharData WhiteSpace = new CharData (DefaultAttr, ' ', 1, 32);

		public CharData (int attribute, Rune rune, int width, int code)
		{
			Attribute = attribute;
			Rune = rune;
			Width = width;
			Code = code;
		}

		// Returns an empty CharData with the specified attribute
		public CharData (int attribute)
		{
			Attribute = attribute;
			Rune = '\u0200';
			Width = 1;
			Code = 0;
		}

		public string GetCharacter()
		{
			return Rune.ToString ().TrimEnd ('\0');
		}

		public override string ToString ()
		{
			return $"[CharData (Attr={Attribute},Rune={Rune},W={Width},Code={Code})]";
		}
	}


}
