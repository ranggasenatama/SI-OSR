#!/usr/bin/env bash

dotnet aspnet-codegenerator controller -name PenggalanganDanaController -m PenggalanganDana -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name DonasiController -m Donasi -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name AnakController -m Anak -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name AbsensiController -m Absensi -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name MateriController -m Materi -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name LombaController -m Lomba -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name UmkmController -m Umkm -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name PembelianController -m Pembelian -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
dotnet aspnet-codegenerator controller -name StaffController -m Staff -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -f
