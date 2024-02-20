﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarBook.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));
        }
    }

/*
    Mediator Service Registiration

Core'un altındaki Application katmanında Mediator servicelerini tek tek program.cs'e yazmak yerine Application katmanında
Services isminde klasör olusturduk.İçine ServiceRegistiration isminde class ekledik ve bu class içine   >>> "public static void AddApplicationService(this IServiceCollection service)" << isminde bir fonkiyon ekledik.Static olmasının sebebi: AddApplicationService metodunu kullanmak için örneğe ihtiyaç yoktur; sadece IServiceCollection türündeki bir nesne üzerinden çağrılır!! 

	 Neden IServiceCollection Parametresi? (hala mediator service registiration)

Bu metodun amacı, servisleri eklemek ve yapılandırmaktır.IServiceCollection, ASP.NET Core uygulamalarında servislerin kaydedildiği bir koleksiyonu temsil eder.Bu koleksiyona servisler eklenir, çıkarılır veya değiştirilir.Bu nedenle, bu metoda IServiceCollection parametresi verilerek, metodun bu koleksiyon üzerinde işlem yapabilmesi sağlanmış olur.


    RegisterServicesFromAssembly Methodu Ne İşe Yarar?

Yukarıda bahsedilen kod örneğinde, RegisterServicesFromAssembly metodu, belirli bir assembly içinde tanımlanan tüm servisleri kaydetmeyi sağlar.Bu, projenin içindeki tüm MediatR servislerini otomatik olarak tanımlar ve kaydeder.


    Assembly Nedir ?

"Assembly" terimi, .NET platformunda derlenmiş bir kodun birimini ifade eder. Bir assembly, genellikle bir DLL (Dynamic Link Library) veya bir EXE(Executable) dosyasıdır.Assembly'ler, bir veya birden fazla .NET dilinde yazılmış bir veya birden fazla tipi (class, interface, struct, vb.) içerir.

Bir.NET uygulaması, bir veya birden fazla assembly içerebilir.Ayrıca, bir projenin derlenmesi sonucunda oluşturulan DLL veya EXE dosyaları da assembly olarak adlandırılır.
*/
}
