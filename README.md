<h1>Redis öğrenirken almış olduğum notları ve kod örneklerini içerir.</h1>

<h2>Redis Kurulumu</h2>
<p>      
   <i>
      - "docker pull redis" komutu ile dockerhub üzerinden Redis image'ini bilgisayarımıza çekiyoruz. 
      - Daha sonra "docker run -p 6379:6379 --name test-redis -d redis" komutu ile çektiğimiz image'i dışarıdan erişebilmek için mapliyoruz ve container ismi vererek ayağa kaldırıyoruz.
      - Containerın ayağa kalktığından emin olduktan sonra, "docker exec -it {containerId} sh" komutu ile Redis container'ımızın içerisine giriyoruz. 
      - "redis-cli" komutuyla artık Redis servera client terminal üzerinden erişim sağlamış oluyoruz. Test amaçlı "set key value" şeklinde bir değer giriyoruz ve çıktı olarak "OK" geri dönüşünü aldığımızdan emin olduktan sonra, ilk verimizi kayıt etmiş bulunuyoruz.
   </i>
</p>
