using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapReaderLib
{
	public class PcapReader: IPcapReader
	{
		

		public PcapReader()
		{
			
		}
		public FileHeader ReadHeader(BinaryReader Reader)
		{
			FileHeader header;
			UInt32 value;


			header = new FileHeader();
				
			header.MagicNumber = Reader.ReadUInt32();
			header.MajorVersion = Reader.ReadUInt16();
			header.MinorVersion = Reader.ReadUInt16();
			header.Reserved1= Reader.ReadUInt32();
			header.Reserved2 = Reader.ReadUInt32();
			header.SnapLen= Reader.ReadUInt32();
			value = Reader.ReadUInt32();
			header.LinkType = value & 0xFFFFFFF;
			header.FCS = (byte)((value & 0xF0000000) >> 28);
				

			return header;


		}
		public PacketRecord ReadPacketRecord(BinaryReader Reader)
		{
			PacketRecord record;

			
			record = new PacketRecord();
				
			record.TimestampSeconds = Reader.ReadUInt32();
			record.TimestampMicroOrNanoSeconds = Reader.ReadUInt32();
			record.CapturedPacketLength = Reader.ReadUInt32();
			record.OriginalPacketLength = Reader.ReadUInt32();
			record.PacketData = new byte[record.CapturedPacketLength];
			Reader.Read(record.PacketData, 0, (int)record.CapturedPacketLength);
				
			
			return record;
		}



	}
}
