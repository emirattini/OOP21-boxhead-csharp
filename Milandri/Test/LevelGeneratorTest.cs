using System.Collections.Generic;

namespace tests
{


	using Assert = org.junit.Assert;
	using Test = org.junit.Test;

	using Point2D = javafx.geometry.Point2D;

	public class LevelGeneratorTest
	{

		/// <summary>
		/// test lettura da file, controllo che gli inidici passati da file di testo
		/// abbiano la giusta posizione
		/// 
		/// </summary>

		public void testReadLevel()
		{

			const int width = 5;
			const int height = 5;

			IDictionary<Point2D, int?> comparer = new Dictionary<Point2D, int?>();

			IDictionary<Point2D, int?> comparator = new Dictionary<Point2D, int?>();

			comparator[new Point2D(0, 0)] = 2;
			comparator[new Point2D(0, 1)] = 2;
			comparator[new Point2D(0, 2)] = 2;
			comparator[new Point2D(0, 3)] = 2;
			comparator[new Point2D(0, 4)] = 2;
			comparator[new Point2D(1, 0)] = 2;
			comparator[new Point2D(1, 1)] = 1;
			comparator[new Point2D(1, 2)] = 1;
			comparator[new Point2D(1, 3)] = 1;
			comparator[new Point2D(1, 4)] = 2;
			comparator[new Point2D(2, 0)] = 2;
			comparator[new Point2D(2, 1)] = 3;
			comparator[new Point2D(2, 2)] = 1;
			comparator[new Point2D(2, 3)] = 1;
			comparator[new Point2D(2, 4)] = 2;
			comparator[new Point2D(3, 0)] = 2;
			comparator[new Point2D(3, 1)] = 1;
			comparator[new Point2D(3, 2)] = 5;
			comparator[new Point2D(3, 3)] = 1;
			comparator[new Point2D(3, 4)] = 2;
			comparator[new Point2D(4, 0)] = 2;
			comparator[new Point2D(4, 1)] = 2;
			comparator[new Point2D(4, 2)] = 2;
			comparator[new Point2D(4, 3)] = 2;
			comparator[new Point2D(4, 4)] = 2;

			System.IO.StreamReader br = null;
			try
			{

				System.IO.Stream @is = this.GetType().getResourceAsStream("/test.txt");
				br = new System.IO.StreamReader(@is);
				int x = 0;
				int y = 0;
				while ((x < width) && (y < height))
				{

					string line = br.ReadLine();
					while (x < width)
					{

						string[] numbers = line.Split(" ", true);

						int num = int.Parse(numbers[x]);
						comparer[new Point2D(y, x)] = num;
						x++;
					}
					if (x == width)
					{
						x = 0;
						y++;
					}
				}
				br.Close();
			}

			catch (ception)
			{
			}

			comparator.forEach((k, v) =>
			{
				Assert.assertEquals(comparer[k], v);
			});

		}
	}
}


internal static class StringHelperClass
{
	
	internal static string SubstringSpecial(this string self, int start, int end)
	{
		return self.Substring(start, end - start);
	}

	
	internal static bool StartsWith(this string self, string prefix, int toffset)
	{
		return self.IndexOf(prefix, toffset, System.StringComparison.Ordinal) == toffset;
	}

	
	internal static string[] Split(this string self, string regexDelimiter, bool trimTrailingEmptyStrings)
	{
		string[] splitArray = System.Text.RegularExpressions.Regex.Split(self, regexDelimiter);

		if (trimTrailingEmptyStrings)
		{
			if (splitArray.Length > 1)
			{
				for (int i = splitArray.Length; i > 0; i--)
				{
					if (splitArray[i - 1].Length > 0)
					{
						if (i < splitArray.Length)
							System.Array.Resize(ref splitArray, i);

						break;
					}
				}
			}
		}

		return splitArray;
	}


	internal static string NewString(sbyte[] bytes)
	{
		return NewString(bytes, 0, bytes.Length);
	}
	internal static string NewString(sbyte[] bytes, int index, int count)
	{
		return System.Text.Encoding.UTF8.GetString((byte[])(object)bytes, index, count);
	}
	internal static string NewString(sbyte[] bytes, string encoding)
	{
		return NewString(bytes, 0, bytes.Length, encoding);
	}
	internal static string NewString(sbyte[] bytes, int index, int count, string encoding)
	{
		return System.Text.Encoding.GetEncoding(encoding).GetString((byte[])(object)bytes, index, count);
	}


	internal static sbyte[] GetBytes(this string self)
	{
		return GetSBytesForEncoding(System.Text.Encoding.UTF8, self);
	}
	internal static sbyte[] GetBytes(this string self, string encoding)
	{
		return GetSBytesForEncoding(System.Text.Encoding.GetEncoding(encoding), self);
	}
	private static sbyte[] GetSBytesForEncoding(System.Text.Encoding encoding, string s)
	{
		sbyte[] sbytes = new sbyte[encoding.GetByteCount(s)];
		encoding.GetBytes(s, 0, s.Length, (byte[])(object)sbytes, 0);
		return sbytes;
	}
}
