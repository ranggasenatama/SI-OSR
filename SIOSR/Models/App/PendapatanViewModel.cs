using System.Collections.Generic;

namespace SIOSR.Models.App {

    public class PendapatanViewModel {

        public IEnumerable<Umkm> Umkms { get; set; }
        public IEnumerable<PenggalanganDana> PenggalanganDanas { get; set; }
    }
}
