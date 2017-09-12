using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SharpMik.IO
{

	/*
	 * Needs to be tidy up, removal of functions that are not needed any more
	 * And chaning of function headers to make more sense.
	 * 
	 * Also to not throw exceptions when hitting EOF, instead passing back how
	 * much data was read.
	 * 
	 */
	public class ModBinaryReader : BinaryReader
	{
		public ModBinaryReader(Stream baseStream)
			: base(baseStream)
		{

		}

		public bool Seek(int offset, SeekOrigin origin)
		{
			BaseStream.Seek(offset, origin);

			return BaseStream.Position < BaseStream.Length;
		}

		public virtual int Tell()
		{
			try
			{
				return (int)(BaseStream.Position);
			}
			catch (System.IO.IOException)
			{
				return -1;
			}
		}

		public virtual byte Readbyte()
		{
			try
			{
				return (byte)this.ReadByte();
			}
			catch
			{
				return byte.MaxValue;
				//throw ioe1;
			}
		}

		public virtual sbyte Readsbyte()
		{
			try
			{
				return (sbyte)this.ReadByte();
			}
			catch (System.IO.IOException ioe1)
			{
				throw ioe1;
			}
		}


		public virtual bool Readbytes(byte[] buffer, int number)
		{
			int pos = 0; 
			while (number > 0)
			{
				buffer[pos++] = Readbyte(); 
				number--;
			} 
			
			return !isEOF();
		}

		public virtual bool Readbytes(sbyte[] buffer, int number)
		{
			int pos = 0;
			while (number > 0)
			{
				buffer[pos++] = (sbyte)Readbyte();
				number--;
			}

			return !isEOF();
		}

		public virtual ushort ReadMotorolaushort()
		{
			byte b1 = this.ReadByte();
			byte b2 = this.ReadByte();

			int ushort1 = (int)b1;
			int ushort2 = (int)b2;

			ushort result = (ushort)(ushort1 << 8);
			result = (ushort)(result | ushort2);
			return result;
		}

		public virtual ushort ReadIntelushort()/* _mm_read_I_ushort*/
		{
			ushort result = Readbyte();
			result |= (ushort)(Readbyte() << 8);
			return result;
		}


		public virtual short ReadMotorolashort()
		{
			short result = (short)(Readbyte() << 8);
			result |= (short)Readbyte();
			return result;
		}

		public virtual bool ReadIntelushorts(ushort[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = ReadIntelushort(); 
				number--;
			} 
			return !isEOF();
		}

		

		public virtual short ReadIntelshort()
		{
			short result = Readbyte();
			result |= (short)(Readbyte() << 8);
			return result;
		}

		public virtual int ReadMotorolauint()
		{
			int result = (ReadMotorolaushort()) << 16;
			result |= ReadMotorolaushort();
			return result;
		}

		public virtual uint ReadInteluint()
		{
			uint result = ReadIntelushort();
			result |= ((uint)ReadIntelushort()) << 16;
			return result;
		}

		public virtual bool ReadInteluints(uint[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = ReadInteluint();
				number--;
			}
			return !isEOF();
		}


		public virtual int ReadMotorolaint()
		{
			return ((int)ReadMotorolauint());
		}

		public virtual int ReadIntelint()
		{
			return ((int)ReadInteluint());
		}

		public string ReadString(int length)
		{
			try
			{
				byte[] tmpBuffer = new byte[length];
				this.Read(tmpBuffer, 0, length);

				return System.Text.UTF8Encoding.UTF8.GetString(tmpBuffer, 0, length).Trim(new char[] {'\0'});
			}
			catch (System.IO.IOException ioe1)
			{
				throw ioe1;
			}
		}

		public virtual bool Readbytes(ushort[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = (ushort)Readbyte(); 
				number--;
			}

			return !isEOF();
		}


		public virtual bool Readbytes(char[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = (char)Readbyte();
				number--;
			}

			return !isEOF();
		}


		public virtual bool ReadShorts(short[] buffer, int number)
		{
			int pos = 0; 
			while (number > 0)
			{
				short result = Readbyte();
				result |= (short)(Readbyte() << 8);
				buffer[pos++] = result;
				number--;
			}
			return !isEOF();
		}

		public virtual bool Readbytes(short[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = (short)Readbyte();
				number--;
			}

			return !isEOF();
		}

		public virtual bool readMotorolashorts(short[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = ReadMotorolashort(); number--;
			} return !isEOF();
		}

		public virtual bool readIntelshorts(short[] buffer, int number)
		{
			int pos = 0; while (number > 0)
			{
				buffer[pos++] = ReadIntelshort(); number--;
			} return !isEOF();
		}

		// isEOF is basically a utility function to catch all the
		// IOExceptions from the dependandt functions.
		// It's also make the code look more like the original
		// C source because it corresponds to feof.
		public virtual bool isEOF()
		{
			try
			{
				return (BaseStream.Position > BaseStream.Length);
			}
			catch (System.IO.IOException)
			{
				return true;
			}
		}

		public void Rewind()
		{
			Seek(0, SeekOrigin.Begin);
		}

	}
}
