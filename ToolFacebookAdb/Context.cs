using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolFacebookAdb
{
    public class ContextDataBitMap
    {
        public Bitmap iconFacebook { get;private set; }
        public Bitmap iconSignIn { get; private set; }
        public Bitmap iconDangKy { get; private set; }
        public Bitmap iconThuCachKhac { get; private set; }
        public Bitmap iconThuCachKhac2 { get; private set; }
        public Bitmap iconUngdungxacthuc { get; private set; }
        public Bitmap iconDangNhap { get; private set; }
        public Bitmap iconDangNhap2 { get; private set; }
        public Bitmap saithongtindangnhap { get; private set; }
        //REg page
        public Bitmap iconCaNhan { get; private set; }
        public Bitmap iconXemthem { get; private set; }
        public Bitmap iconPage { get; private set; }
        public Bitmap iconTao { get; private set; }
        public Bitmap iconBatDau { get; private set; }
        public Bitmap iconTiep { get; private set; }
        public Bitmap imgBanNhac { get; private set; }
        public Bitmap imgSucKhoe { get; private set; }
        public Bitmap imgCuaHang { get; private set; }
        public Bitmap imgXong { get; private set; }
        //reels
        public Bitmap iconReels { get; private set; }
        public Bitmap iconKinhLup { get; private set; }
        public Bitmap iconHoaKy { get; private set; }
        public Bitmap iconThuLai { get; private set; }
        public Bitmap iconboqua2 { get; private set; }
        public Bitmap iconChoPhep { get; private set; }
        public Bitmap iconChoPhep2 { get; private set; }
        public Bitmap iconFacebook2 { get; private set; }

        public Bitmap iconMenu { get; private set; }
        public Bitmap iconChoPhepTruyCap { get; private set; }

        public Bitmap iconNoThank { get; private set; }
        public Bitmap iconOK { get; private set; }

        public Bitmap iconVPN { get; private set; }
        public Bitmap iconVPN2 { get; private set; }

        public Bitmap iconLucKhac { get; private set; }
        public Bitmap iconLucKhac2 { get; private set; }
        public Bitmap imgMaybeLater { get; private set; }
        public ContextDataBitMap()
        {
            iconFacebook = (Bitmap)Bitmap.FromFile("Image//iconMeta.png");
            iconDangKy = (Bitmap)Bitmap.FromFile("Image//taotaikhoan.png");
            iconThuCachKhac = (Bitmap)Bitmap.FromFile("Image//thucachkhac.png");
            iconThuCachKhac2 = (Bitmap)Bitmap.FromFile("Image//thucachkhac2.png");
            iconUngdungxacthuc = (Bitmap)Bitmap.FromFile("Image//ungdungxacthuc.png");
            iconDangNhap = (Bitmap)Bitmap.FromFile("Image//iconDangNhap.png");
            iconDangNhap2 = (Bitmap)Bitmap.FromFile("Image//iconDangNhap2.png");
            saithongtindangnhap = (Bitmap)Bitmap.FromFile("Image//iconDangNhap.png");
            iconCaNhan = (Bitmap)Bitmap.FromFile("Image//iconCanhan.png");
            iconXemthem = (Bitmap)Bitmap.FromFile("Image//iconXemthem.png");
            iconPage = (Bitmap)Bitmap.FromFile("Image//iconPage.png");
            iconTao = (Bitmap)Bitmap.FromFile("Image//iconTao.png");
            iconBatDau = (Bitmap)Bitmap.FromFile("Image//iconBatDau.png");
            iconTiep = (Bitmap)Bitmap.FromFile("Image//iconTiep.png");
            imgBanNhac = (Bitmap)Bitmap.FromFile("Image//nhacsy.png");
            imgSucKhoe = (Bitmap)Bitmap.FromFile("Image//suckhoe.png");
            imgCuaHang = (Bitmap)Bitmap.FromFile("Image//cuahang.png");
            imgXong = (Bitmap)Bitmap.FromFile("Image//iconxong.png");
            iconReels = (Bitmap)Bitmap.FromFile("Image//iconreels.png");
            iconSignIn = (Bitmap)Bitmap.FromFile("Image//iconSignIn.png");
            iconKinhLup = (Bitmap)Bitmap.FromFile("Image//iconkinhlup.png");
            iconHoaKy = (Bitmap)Bitmap.FromFile("Image//iconUS.png");
            iconThuLai = (Bitmap)Bitmap.FromFile("Image//iconThuLai.png");
            iconboqua2 = (Bitmap)Bitmap.FromFile("Image//iconboqua2.png");
            iconChoPhep = (Bitmap)Bitmap.FromFile("Image//iconChophep.png");
            iconChoPhep2 = (Bitmap)Bitmap.FromFile("Image//iconChophep2.png");
            iconFacebook2 = (Bitmap)Bitmap.FromFile("Image//iconfacebook2.png");
            iconMenu = (Bitmap)Bitmap.FromFile("Image//iconMenu.png");
            iconChoPhepTruyCap = (Bitmap)Bitmap.FromFile("Image//chopheptruycap.png");
            iconNoThank = (Bitmap)Bitmap.FromFile("Image//iconNOThank.png");
            iconOK = (Bitmap)Bitmap.FromFile("Image//iconOK.png");
            iconVPN = (Bitmap)Bitmap.FromFile("Image//iconVPN.png");
            iconVPN2 = (Bitmap)Bitmap.FromFile("Image//iconVPN2.png");
            iconLucKhac = (Bitmap)Bitmap.FromFile("Image//iconLucKhac.png");
            iconLucKhac2 = (Bitmap)Bitmap.FromFile("Image//iconLucKhac2.png");
            imgMaybeLater = (Bitmap)Bitmap.FromFile("Image//maybelater.png");
        }

    }
   
}
