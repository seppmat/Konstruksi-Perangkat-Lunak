using Microsoft.AspNetCore.Mvc;

namespace tpModul9
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        // Data static (tanpa database)
        private static readonly List<Mahasiswa> mahasiswaList =
        [
            new Mahasiswa { Nama = "Yosep Warih Martua Manik", Nim = "103082400017" },
        new Mahasiswa { Nama = "Muhamad Rozi", Nim = "103082400018" },
        new Mahasiswa { Nama = "Daffa Surya Ramadhan", Nim = "103082400019" }
        ];

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<List<Mahasiswa>> GetMahasiswa()
        {
            return mahasiswaList;
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            return mahasiswaList[index];
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mhs)
        {
            mahasiswaList.Add(mhs);
            return Ok();
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
                return NotFound();

            mahasiswaList.RemoveAt(index);
            return Ok();
        }
    }
}
