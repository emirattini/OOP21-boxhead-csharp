using System.Collections.Generic;

namespace boxhead.model.level
{

	using Point2D = javafx.geometry.Point2D;
	using Pair = javafx.util.Pair;


	using LevelView = boxhead.view.level.LevelView;
	using LevelViewImpl = boxhead.view.level.LevelViewImpl;
	using TileFactory = boxhead.view.world.tile.TileFactory;
	using TileFactoryImpl = boxhead.view.world.tile.TileFactoryImpl;

	/// <summary>
	/// Implementation of <seealso cref="LevelGenerator"/>.
	/// </summary>
	public class LevelGeneratorImpl : LevelGenerator
	{

		private const int MAP_WIDTH = 29;
		private const int MAP_HEIGHT = 15;

		private static IDictionary<Point2D, int?> level = new Dictionary<Point2D, int?>();
		private readonly TileFactory tFactory;

		/// <summary>
		/// Contructor that takes only tileSize. </summary>
		/// <param name="ts"> </param>
		public LevelGeneratorImpl(double ts)
		{
			this.tFactory = new TileFactoryImpl(ts);
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override Pair<Level, LevelView> loadLevel(double width, double height, double tileSize)
		{

			IDictionary<Point2D, int?> level = readLevel();
			return new Pair<>(LevelGeneratorImpl.generateLevel(level, width, height, tileSize), LevelGeneratorImpl.generateLevelView(level, tFactory, tileSize));
		}

		/// <summary>
		/// Method to read the level from a file. </summary>
		/// <returns> Map with Point2D and type of the tile(in integer). </returns>
		private IDictionary<Point2D, int?> readLevel()
		{
			System.IO.StreamReader br = null;
			try
			{

				System.IO.Stream @is = this.GetType().getResourceAsStream("/prova.txt");
				br = new System.IO.StreamReader(@is);
				int x = 0;
				int y = 0;
				while ((x < MAP_WIDTH) && (y < MAP_HEIGHT))

					string line = br.ReadLine();
					while (x < MAP_WIDTH)
					{

						string[] numbers = line.Split(" ", true);

						int num = int.Parse(numbers[x]);
						LevelGeneratorImpl.level[new Point2D(x, y)] = num;
						x++;
					}
					if (x == MAP_WIDTH)
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
			return LevelGeneratorImpl.level;
		}

		/// <summary>
		/// Method to instantiate a new Level. </summary>
		/// <param name="level"> </param>
		/// <param name="width"> </param>
		/// <param name="height"> </param>
		/// <param name="tileSize">
		/// @return </param>
		private static Level generateLevel(IDictionary<Point2D, int?> level, double width, double height, double tileSize)
		{
			return new LevelImpl(level, width, height, tileSize);

		}

		/// <summary>
		/// Method to instantiate a new LevelView. </summary>
		/// <param name="level"> </param>
		/// <param name="tf"> </param>
		/// <param name="tileSize">
		/// @return </param>
		private static LevelView generateLevelView(IDictionary<Point2D, int?> level, TileFactory tf, double tileSize)
		{
			return new LevelViewImpl(level, tf, tileSize);
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
