﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjectNhom12.Models
{
    public partial class QLSinhvien_NETContext : DbContext
    {
        public QLSinhvien_NETContext()
        {
        }

        public QLSinhvien_NETContext(DbContextOptions<QLSinhvien_NETContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dieukien> Dieukien { get; set; }
        public virtual DbSet<Hocphan> Hocphan { get; set; }
        public virtual DbSet<Ketqua> Ketqua { get; set; }
        public virtual DbSet<Khoa> Khoa { get; set; }
        public virtual DbSet<Monhoc> Monhoc { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Sinhvien> Sinhvien { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
<<<<<<< HEAD
                optionsBuilder.UseSqlServer("Server=DESKTOP-6P4KML7\\SQLEXPRESS2;Database=QLSinhvien_NET;Integrated Security=True;");
=======
                optionsBuilder.UseSqlServer("Server=DESKTOP-SSJ4G38SQLEXPRESS;Database=QLSinhvien_NET;Integrated Security=True;");
>>>>>>> 12d2f9f81db539f642924c3abc29850d8065118c
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Dieukien>(entity =>
            {
                entity.HasKey(e => new { e.MaMh, e.MaMhTruoc })
                    .HasName("pk_Dieukien");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaMhTruoc)
                    .HasColumnName("MaMh_truoc")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.DieukienMaMhNavigation)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_Dieukien_Mh");

                entity.HasOne(d => d.MaMhTruocNavigation)
                    .WithMany(p => p.DieukienMaMhTruocNavigation)
                    .HasForeignKey(d => d.MaMhTruoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pk_Dieukien_Mh_truoc");
            });

            modelBuilder.Entity<Hocphan>(entity =>
            {
                entity.HasKey(e => e.MaHp)
                    .HasName("pk_Hocphan");

                entity.Property(e => e.MaHp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Giangvien).HasMaxLength(100);

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Hocphan)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("fk_Hocphan_k");
            });

            modelBuilder.Entity<Ketqua>(entity =>
            {
                entity.HasKey(e => new { e.MaSv, e.MaHp })
                    .HasName("pk_Ketqua");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaHp)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaHpNavigation)
                    .WithMany(p => p.Ketqua)
                    .HasForeignKey(d => d.MaHp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ketqua_HP");

                entity.HasOne(d => d.MaSvNavigation)
                    .WithMany(p => p.Ketqua)
                    .HasForeignKey(d => d.MaSv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Ketqua_SV");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("pk_khoa");

                entity.HasIndex(e => e.TenKhoa)
                    .HasName("UQ__Khoa__AAD36158F68C1AA0")
                    .IsUnique();

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.HinhKhoa).IsUnicode(false);

                entity.Property(e => e.TenKhoa)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Monhoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("pk_Monhoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenMh)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Monhoc)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("fk_Monhoc");
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("pk_nhanvien");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20);

                entity.Property(e => e.Diachi).HasMaxLength(255);

                entity.Property(e => e.Gioitinh).HasMaxLength(4);

                entity.Property(e => e.HinhNv)
                    .HasColumnName("HinhNV")
                    .IsUnicode(false);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ngayvaolam).HasColumnType("datetime");

                entity.Property(e => e.TenNv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.NhanVien)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("fk_nhanvien_k");
            });

            modelBuilder.Entity<Sinhvien>(entity =>
            {
                entity.HasKey(e => e.MaSv)
                    .HasName("pk_sinhvien");

                entity.Property(e => e.MaSv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20);

                entity.Property(e => e.Diachi).HasMaxLength(255);

                entity.Property(e => e.Gioitinh).HasMaxLength(4);

                entity.Property(e => e.HinhSv)
                    .HasColumnName("HinhSV")
                    .IsUnicode(false);

                entity.Property(e => e.MaKhoa)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenSv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.Sinhvien)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("fk_sinhvien_k");
            });
        }
    }
}
