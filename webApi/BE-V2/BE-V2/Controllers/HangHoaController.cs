using BE_V2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BE_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<Hanghoa> RS_HangHoa = new List<Hanghoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(RS_HangHoa);
        }

        [HttpPost]
        public IActionResult Create(HanghoaVM hanghoaVM)
        {
            var hanghoa = new Hanghoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hanghoaVM.TenHangHoa,
                DonGia = hanghoaVM.DonGia
            };
            RS_HangHoa.Add(hanghoa);
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById (string id)
        {
            try
            {
                var hanghoa = RS_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id)); 
                if(hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Hanghoa hanghoa_update)
        {
            try
            {
                var hanghoa = RS_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa == null)
                {
                    return NotFound();
                }

                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }

                hanghoa.TenHangHoa = hanghoa_update.TenHangHoa;
                hanghoa.DonGia = hanghoa_update.DonGia;

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var hanghoa = RS_HangHoa.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if(hanghoa == null)
                {
                    return NotFound();
                }

                RS_HangHoa.Remove(hanghoa);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
