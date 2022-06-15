using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IQrGeneratorService
    {
        byte[] GenerateQR(string textToEncode, string hexColour1, string hexColour2);
    }
}
