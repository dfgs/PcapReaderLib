using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapReaderLib
{
	public class FileHeader:PcapBlock
	{
		public uint MagicNumber
		{
			get;
			set;
		}
		public ushort MajorVersion
		{
			get;
			set;
		}
		public ushort MinorVersion
		{
			get;
			set;
		}

		public uint Reserved1
		{
			get;
			set;
		}
		public uint Reserved2
		{
			get;
			set;
		}

		public uint SnapLen
		{
			get;
			set;
		}

		public uint LinkType
		{
			get;
			set;
		}

		public byte FCS
		{
			get;
			set;
		}
		
		public FileHeader()
		{

		}

		public DateTime GetTimeTimeUTC(PacketRecord Record )
		{
			ArgumentNullException.ThrowIfNull(Record);

			switch(MagicNumber)
			{
				case 0xA1B2C3D4:return new DateTime(1970, 1, 1).AddSeconds(Record.TimestampSeconds).AddMicroseconds(Record.TimestampMicroOrNanoSeconds);
				case 0xA1B23C4D:return new DateTime(1970, 1, 1).AddSeconds(Record.TimestampSeconds).AddMicroseconds(Record.TimestampMicroOrNanoSeconds*1000);
			}

			throw new InvalidDataException("Invalid magic number");
		}



	}
}
