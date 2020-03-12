using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeKod.Data
{
    public class KafeContext:DbContext
    {
        public KafeContext() : base("name=KafeContext")
        {

            //Urunler = new List<Urun>();
            //AktifSiparisler = new List<Siparis>();
            //GecmisSiparisler = new List<Siparis>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)  //ürünleri silince içinde o ürün geçen siparişleri de silmesini önlemek için kullandık hata verir silince
        {
            modelBuilder.Entity<Urun>().ToTable("Urunler");    //Urunler.csdeki [table("urunler")] yerine bu da kullanılabilir 
            modelBuilder.Entity<Urun>()
                .HasMany(x=>x.SiparisDetaylar)
                .WithRequired(x=>x.Urun)
                .HasForeignKey(x=>x.UrunId)
                .WillCascadeOnDelete(false);
        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis>Siparisler { get; set; }
        public DbSet<SiparisDetay>SiparisDetaylar { get; set; }
      
    }
}
