using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ImarRuhsatTakipApp.Models
{
    [MetadataType(typeof(KullanicilarMetadata))]
    public partial class Kullanicilar
    {
    }

    [MetadataType(typeof(MuteahhitMetadata))]
    public partial class Muteahhit
    {
    }
}