using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcapReaderLib
{
	public class PacketRecord:PcapBlock
	{
		public uint TimestampSeconds
		{
			get;
			set;
		}
		public uint TimestampMicroOrNanoSeconds
		{
			get;
			set;
		}


		public uint CapturedPacketLength
		{
			get;
			set;
		}

		public uint OriginalPacketLength
		{
			get;
			set;
		}

		public byte[] PacketData
		{
			get;
			set;
		}

		public PacketRecord()
		{
			PacketData = new byte[] { };
		}




	}
}
