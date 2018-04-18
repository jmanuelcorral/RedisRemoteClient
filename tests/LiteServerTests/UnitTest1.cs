using LiteServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LiteServerTests
{

   
    public class StressTest
    {
        private readonly IServiceBus<BaseCommand> _redisClient;

        public static IEnumerable<object[]> MyNifData
        {
            get
            {
                yield return new object[] { "131600802K", true };
                yield return new object[] { "2805472N", true };
                yield return new object[] { "3K0320721D", true };
                yield return new object[] { "4K0857404X", true };
                yield return new object[] { "5L4111181T", true };
                yield return new object[] { "6M2825186G", true };
                yield return new object[] { "7M2834272M", true };
                yield return new object[] { "8M0344281V", true };
                yield return new object[] { "9X9422288Q", true };
                yield return new object[] { "1Y0042609G", true };
                yield return new object[] { "2A07017874", true };
                yield return new object[] { "3B03271228", true };
                yield return new object[] { "4C58446204", true };
                yield return new object[] { "5D59101402", true };
                yield return new object[] { "6E53400438", true };
                yield return new object[] { "7F08401879", true };
                yield return new object[] { "8H53324315", true };
                yield return new object[] { "9J58516873", true };
                yield return new object[] { "0N2041215A", true };
                yield return new object[] { "1P3501200D", true };
                yield return new object[] { "2Q0861001F", true };
                yield return new object[] { "3R4100699J", true };
                yield return new object[] { "4S3511001D", true };
                yield return new object[] { "5U63423966", true };
                yield return new object[] { "6V38572863", true };
                yield return new object[] { "731600802P", false };
                yield return new object[] { "8805472T", false };
                yield return new object[] { "9K0320721R", false };
                yield return new object[] { "1K0857404N", false };
                yield return new object[] { "2L4111181A", false };
                yield return new object[] { "5M2825186J", false };
                yield return new object[] { "M72834272D", false };
                yield return new object[] { "M30344281T", false };
                yield return new object[] { "X93422288B", false };
                yield return new object[] { "Y05042609T", false };
                yield return new object[] { "A077017875", false };
                yield return new object[] { "B033271229", false };
                yield return new object[] { "C581446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E534050437", false };
                yield return new object[] { "F084071877", false };
                yield return new object[] { "H533284311", false };
                yield return new object[] { "J585136872", false };
                yield return new object[] { "N20412215B", false };
                yield return new object[] { "P350123200A", false };
                yield return new object[] { "Q0861056401D", false };
                yield return new object[] { "R41006996B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U634237964", false };
                yield return new object[] { "V385728662", false };
                yield return new object[] { "316008026K", true };
                yield return new object[] { "805472N",true };
                yield return new object[] { "K03220721D", true };
                yield return new object[] { "K08527404X", true };
                yield return new object[] { "L41112181T", true };
                yield return new object[] { "M28251286G", true };
                yield return new object[] { "M28342732M", true };
                yield return new object[] { "M03442814V", true };
                yield return new object[] { "X9422288Q54", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "1A07017874", true };
                yield return new object[] { "B203271228", true };
                yield return new object[] { "C528446204", true };
                yield return new object[] { "D593101402", true };
                yield return new object[] { "E534400438", true };
                yield return new object[] { "F084051879", true };
                yield return new object[] { "H533245315", true };
                yield return new object[] { "J585168673", true };
                yield return new object[] { "N20412153A", true };
                yield return new object[] { "P3501200D", true };
                yield return new object[] { "Q30861001F", true };
                yield return new object[] { "R43100699J", true };
                yield return new object[] { "S35311001D", true };
                yield return new object[] { "U634323966", true };
                yield return new object[] { "V385732863", true };
                yield return new object[] { "316008302P", false };
                yield return new object[] { "805472T3", false };
                yield return new object[] { "K03207213R", false };
                yield return new object[] { "K0857404N3", false };
                yield return new object[] { "5L4111181A", false };
                yield return new object[] { "M62825186J", false };
                yield return new object[] { "M27834272D", false };
                yield return new object[] { "M03744281T", false };
                yield return new object[] { "X942872288B", false };
                yield return new object[] { "Y00426809T", false };
                yield return new object[] { "A0701788875", false };
                yield return new object[] { "B032712298", false };
                yield return new object[] { "C58446201", false };
                yield return new object[] { "2D59101400", false };
                yield return new object[] { "E4353400437", false };
                yield return new object[] { "F0845401877", false };
                yield return new object[] { "H533254311", false };
                yield return new object[] { "J5851666872", false };
                yield return new object[] { "N204121555B", false };
                yield return new object[] { "P35012004A", false };
                yield return new object[] { "Q0861044401D", false };
                yield return new object[] { "R410069449B", false };
                yield return new object[] { "S35110014J", false };
                yield return new object[] { "U634239644", false };
                yield return new object[] { "V385728642", false };
                yield return new object[] { "316008024K", true };
                yield return new object[] { "80547122N", true };
                yield return new object[] { "K0320721D4", true };
                yield return new object[] { "K0853247404X", true };
                yield return new object[] { "L411112381T", true };
                yield return new object[] { "M2825183426G", true };
                yield return new object[] { "M2834272M342", true };
                yield return new object[] { "M0344234281V", true };
                yield return new object[] { "X9422282438Q", true };
                yield return new object[] { "Y0042609G243", true };
                yield return new object[] { "A76807017874", true };
                yield return new object[] { "B03678271228", true };
                yield return new object[] { "C58476846204", true };
                yield return new object[] { "D59101487602", true };
                yield return new object[] { "E5340043876", true };
                yield return new object[] { "F0sad8401879", true };
                yield return new object[] { "H5332daa4315", true };
                yield return new object[] { "J58516da873", true };
                yield return new object[] { "N2041215dsA", true };
                yield return new object[] { "P3501200Dads", true };
                yield return new object[] { "Q08610as01F", true };
                yield return new object[] { "R4100699dJ", true };
                yield return new object[] { "S351100da1D", true };
                yield return new object[] { "U6342396asd6", true };
                yield return new object[] { "V385728asd63", true };
                yield return new object[] { "31600asd802P", false };
                yield return new object[] { "80547asd2T", false };
                yield return new object[] { "K03207asd21R", false };
                yield return new object[] { "K0857404fN", false };
                yield return new object[] { "L411ghj1181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834ghj272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X9422ghj288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A070178hjg75", false };
                yield return new object[] { "B032712gh29", false };
                yield return new object[] { "C58446201j", false };
                yield return new object[] { "ghD59101400", false };
                yield return new object[] { "E5j3400437", false };
                yield return new object[] { "F0ghj8401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J5ghj8516872", false };
                yield return new object[] { "N204gh1215B", false };
                yield return new object[] { "P3501j200A", false };
                yield return new object[] { "Q08610gjh01D", false };
                yield return new object[] { "R4100699hjgB", false };
                yield return new object[] { "cxS3511001J", false };
                yield return new object[] { "Uvx63423964", false };
                yield return new object[] { "V38vxc572862", false };
                yield return new object[] { "31600vc802K", true };
                yield return new object[] { "805472xvcN", true };
                yield return new object[] { "K032072xcv1D", true };
                yield return new object[] { "hjK0857404X", true };
                yield return new object[] { "Lgh4111181T", true };
                yield return new object[] { "M28gj25186G", true };
                yield return new object[] { "M283hj4272M", true };
                yield return new object[] { "M0344ghj281V", true };
                yield return new object[] { "X942228gjh8Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "Atr07017874", true };
                yield return new object[] { "B0yr3271228", true };
                yield return new object[] { "C584yt46204", true };
                yield return new object[] { "D5910ryt1402", true };
                yield return new object[] { "E534004ryt38", true };
                yield return new object[] { "F08401879ryt", true };
                yield return new object[] { "H5343324315", true };
                yield return new object[] { "J5855316873", true };
                yield return new object[] { "N204125415A", true };
                yield return new object[] { "P3501203540D", true };
                yield return new object[] { "Q0861001F354", true };
                yield return new object[] { "R4100699J", true };
                yield return new object[] { "S3511001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V38572863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "805472T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K0857404N", false };
                yield return new object[] { "L4111181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X9422288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A07017875", false };
                yield return new object[] { "B03271229", false };
                yield return new object[] { "C58446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J58516872", false };
                yield return new object[] { "N2041215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R4100699B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U63423964", false };
                yield return new object[] { "V38572862", false };
                yield return new object[] { "31600802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "K0857404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M2825186G", true };
                yield return new object[] { "M2834272M", true };
                yield return new object[] { "M0344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "A07017874", true };
                yield return new object[] { "B03271228", true };
                yield return new object[] { "C58446204", true };
                yield return new object[] { "D59101402", true };
                yield return new object[] { "E53400438", true };
                yield return new object[] { "F08401879", true };
                yield return new object[] { "H53324315", true };
                yield return new object[] { "J58516873", true };
                yield return new object[] { "N2041215A", true };
                yield return new object[] { "P3501200D", true };
                yield return new object[] { "Q0861001F", true };
                yield return new object[] { "R4100699J", true };
                yield return new object[] { "S3511001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V38572863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "805472T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K0857404N", false };
                yield return new object[] { "L4111181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X9422288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A07017875", false };
                yield return new object[] { "B03271229", false };
                yield return new object[] { "C58446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J58516872", false };
                yield return new object[] { "N2041215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R4100699B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U63423964", false };
                yield return new object[] { "V38572862", false };
                yield return new object[] { "31600802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "K0857404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M2825186G", true };
                yield return new object[] { "M2834272M", true };
                yield return new object[] { "M0344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "A07017874", true };
                yield return new object[] { "B03271228", true };
                yield return new object[] { "C58446204", true };
                yield return new object[] { "D59101402", true };
                yield return new object[] { "E53400438", true };
                yield return new object[] { "F08401879", true };
                yield return new object[] { "H53324315", true };
                yield return new object[] { "J58516873", true };
                yield return new object[] { "N2041215A", true };
                yield return new object[] { "P3501200D", true };
                yield return new object[] { "Q0861001F", true };
                yield return new object[] { "R4100699J", true };
                yield return new object[] { "S3511001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V38572863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "805472T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K0857404N", false };
                yield return new object[] { "L4111181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X9422288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A07017875", false };
                yield return new object[] { "B03271229", false };
                yield return new object[] { "C58446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J58516872", false };
                yield return new object[] { "N2041215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R4100699B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U63423964", false };
                yield return new object[] { "V38572862", false };
                yield return new object[] { "31600802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "K0857404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M2825186zxcG", true };
                yield return new object[] { "M2834272M", true };
                yield return new object[] { "M0344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "A07017874", true };
                yield return new object[] { "B03271228", true };
                yield return new object[] { "C58446204", true };
                yield return new object[] { "D59101402", true };
                yield return new object[] { "E53400438", true };
                yield return new object[] { "F08zcx401879", true };
                yield return new object[] { "H53324315", true };
                yield return new object[] { "J585zxc1215A", true };
                yield return new object[] { "P350zxc1200D", true };
                yield return new object[] { "Q0861001F", true };
                yield return new object[] { "R41zxc00699J", true };
                yield return new object[] { "S3511001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V38572863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "805zxczxc472T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K0857404N", false };
                yield return new object[] { "L4111181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X9422288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A0701cxzc7875", false };
                yield return new object[] { "B032zxc71229", false };
                yield return new object[] { "C58zxc446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J58516872", false };
                yield return new object[] { "N20zxc41215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R410zcx0699B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U63423964", false };
                yield return new object[] { "V38572862", false };
                yield return new object[] { "3160sdf0802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "K0857404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M2sdf825186G", true };
                yield return new object[] { "M2834272M", true };
                yield return new object[] { "M0344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y00sd42609G", true };
                yield return new object[] { "A07f017874", true };
                yield return new object[] { "B03271228", true };
                yield return new object[] { "C584dfsdf46204", true };
                yield return new object[] { "D59sd1s01402", true };
                yield return new object[] { "E53400438", true };
                yield return new object[] { "F084sd1215A", true };
                yield return new object[] { "P3501200D", true };
                yield return new object[] { "Q0861f001F", true };
                yield return new object[] { "R410df1001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V385f2863", true };
                yield return new object[] { "cx", false };
                yield return new object[] { "80547v2T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K0857404N", false };
                yield return new object[] { "L41zxc11181A", false };
                yield return new object[] { "M2df344281T", false };
                yield return new object[] { "X94zxcf42609T", false };
                yield return new object[] { "A07sd017875", false };
                yield return new object[] { "B03df446201", false };
                yield return new object[] { "D591zcxcz01400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H533sdf24311", false };
                yield return new object[] { "J5851zxczxc6872", false };
                yield return new object[] { "N2041215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R4100699B", false };
                yield return new object[] { "S3df511001J", false };
                yield return new object[] { "U6f8572862", false };
                yield return new object[] { "31sd600802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "K08sdf57404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M282sdf4272M", true };
                yield return new object[] { "M0344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "A07017sdf874", true };
                yield return new object[] { "B03271228", true };
                yield return new object[] { "C58446204", true };
                yield return new object[] { "D59101402", true };
                yield return new object[] { "Esdf53400438", true };
                yield return new object[] { "Ff8401879", true };
                yield return new object[] { "H5s8516873", true };
                yield return new object[] { "N2sdf041215A", true };
                yield return new object[] { "P3fsdf861001F", true };
                yield return new object[] { "R4100699J", true };
                yield return new object[] { "S3511001D", true };
                yield return new object[] { "U634f23966", true };
                yield return new object[] { "V38572863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "8054f72T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K085sd1181A", false };
                yield return new object[] { "M2825186J", false };
                yield return new object[] { "M2834272D", false };
                yield return new object[] { "M0344281T", false };
                yield return new object[] { "X942sdf7875", false };
                yield return new object[] { "B0327sdf1229", false };
                yield return new object[] { "C58446201", false };
                yield return new object[] { "D59101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08401877", false };
                yield return new object[] { "H53324311", false };
                yield return new object[] { "J58516872", false };
                yield return new object[] { "N2041215B", false };
                yield return new object[] { "P3501200A", false };
                yield return new object[] { "Q0861001D", false };
                yield return new object[] { "R4100699B", false };
                yield return new object[] { "S3234511001J", false };
                yield return new object[] { "U642343423964", false };
                yield return new object[] { "V38572862", false };
                yield return new object[] { "312342600802K", true };
                yield return new object[] { "805472N", true };
                yield return new object[] { "K0320721D", true };
                yield return new object[] { "23K0823457404X", true };
                yield return new object[] { "L4111181T", true };
                yield return new object[] { "M2825186G", true };
                yield return new object[] { "M2834272M", true };
                yield return new object[] { "M40344281V", true };
                yield return new object[] { "X9422288Q", true };
                yield return new object[] { "Y0042609G", true };
                yield return new object[] { "A07017874", true };
                yield return new object[] { "B403271228", true };
                yield return new object[] { "C52348446204", true };
                yield return new object[] { "D52343400438", true };
                yield return new object[] { "F0238401879", true };
                yield return new object[] { "H543458516873", true };
                yield return new object[] { "N42041215A", true };
                yield return new object[] { "P33423100699J", true };
                yield return new object[] { "S3234512311001D", true };
                yield return new object[] { "U63423966", true };
                yield return new object[] { "V38372863", true };
                yield return new object[] { "31600802P", false };
                yield return new object[] { "8054472T", false };
                yield return new object[] { "K0320721R", false };
                yield return new object[] { "K084231181A", false };
                yield return new object[] { "M31232825186J", false };
                yield return new object[] { "M283434272D", false };
                yield return new object[] { "M0ad4s3234422288B", false };
                yield return new object[] { "Y0042609T", false };
                yield return new object[] { "A07017875", false };
                yield return new object[] { "B03243271229", false };
                yield return new object[] { "C584dsf46201", false };
                yield return new object[] { "D59423101400", false };
                yield return new object[] { "E53400437", false };
                yield return new object[] { "F08423401877", false };
                yield return new object[] { "H533sd24311", false };
                yield return new object[] { "J585f23416872", false };
                yield return new object[] { "N204f1215B", false };
                yield return new object[] { "P354sd232301200A", false };
                yield return new object[] { "Q086s1001D", false };
                yield return new object[] { "R410sdff0699B", false };
                yield return new object[] { "S3511001J", false };
                yield return new object[] { "U634s72862", false };
            }
        }

       
        public StressTest()
        {
            ServiceBusConfiguration config = new ServiceBusConfiguration()
            {
                Host = "localhost",
                Port = 6379,
                ChannelName = "ChannelTest"
            };

            _redisClient = new ServiceBus<BaseCommand>(config);
            _redisClient.Subscribe(command =>
            {
                Console.WriteLine($"Sended: {command.RemoteCommand} with result {command.RemoteOutput}");
            });
        }
        
        [Theory]
        [MemberData(nameof(MyNifData))]
        public void TestCommands(string command, bool isValid)
        {
            _redisClient.Publish(new BaseCommand() { RemoteCommand = command });
        }

        [Theory]
        [MemberData(nameof(MyNifData))]
        public void TestCommandsMultipleInstances(string commandtoExecute, bool isValid)
        {
            ServiceBusConfiguration config = new ServiceBusConfiguration()
            {
                Host = "localhost",
                Port = 6379,
                ChannelName = "ChannelTest"
            };

            using (var redisClient = new ServiceBus<BaseCommand>(config))
            {
                redisClient.Subscribe(command =>
                {
                    Console.WriteLine($"Sended: {command.RemoteCommand} with result {command.RemoteOutput}");
                });
                redisClient.Publish(new BaseCommand() {RemoteCommand = commandtoExecute});
            }
        }

        [Fact]
        public void TestConcurrencyMultipleInstances()
        {
            Parallel.ForEach(MyNifData, (data) =>
            {
                ServiceBusConfiguration config = new ServiceBusConfiguration()
                {
                    Host = "localhost",
                    Port = 6379,
                    ChannelName = "ChannelTest"
                };

                using (var redisClient = new ServiceBus<BaseCommand>(config))
                {
                    redisClient.Subscribe(command =>
                    {
                        Console.WriteLine($"Sended: {command.RemoteCommand} with result {command.RemoteOutput}");
                    });
                    redisClient.Publish(new BaseCommand() { RemoteCommand = data[0].ToString() });
                }
            });
        }

        [Fact]
        public void TestConcurrencySingleInstance()
        {
            Parallel.ForEach(MyNifData, (data) =>
            {
                _redisClient.Publish(new BaseCommand() { RemoteCommand = data[0].ToString() });
            });
        }
    }
}
