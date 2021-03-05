using Molemax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.Repository
{
    public interface IMolemaxRepository
    {
        IRepository<Patient> Patients { get; }
        IRepository<Ethnicgroup> Ethnicgroups { get; }
        IRepository<EyeColor> EyeColors { get; }
        IRepository<Complexion> Complexions { get; }
        IRepository<HairColor> HairColors { get; }
        IRepository<SkinColor> SkinColors { get; }
        IRepository<Country> Countrys { get; }
        IRepository<DEFMakroLokal> DEFMakroLokals { get; }
        IRepository<DEFMikroLokal> DEFMikroLokals { get; }
        IRepository<DEFLocalTxt> DEFLocalTxts { get; }
        IRepository<DEFDiagnoses> DEFDiagnoses { get; }
        IRepository<DEFAllSkin> DEFAllSkins { get; }
        IRepository<Diagsource> Diagsources { get; }
        IRepository<Diagnose> Diagnoses { get; }
        IRepository<Timestamp> Timestamps { get; }
        IRepository<Image> Images { get; }
        IRepository<Makro> Makros { get; }
        IRepository<Closeup> Closeups { get; }
        IRepository<ImgDiag> ImgDiags { get; }
        IRepository<Mikro> Mikros { get; }
        IRepository<Fup> Fups { get; }
        IRepository<ExpressImage> ExpressImages { get; }
    }
}
