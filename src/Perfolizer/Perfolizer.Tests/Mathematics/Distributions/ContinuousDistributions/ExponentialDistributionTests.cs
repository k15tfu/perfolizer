
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Perfolizer.Mathematics.Distributions.ContinuousDistributions;
using Perfolizer.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Perfolizer.Tests.Mathematics.Distributions.ContinuousDistributions
{
    public class ExponentialDistributionTests : DistributionTestsBase
    {
        protected override double Eps => 1e-9;

        public ExponentialDistributionTests(ITestOutputHelper output) : base(output)
        {
        }

        private static readonly double[] DefaultX =
        {
            0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1, 1.1, 1.2,
            1.3, 1.4, 1.5, 1.6, 1.7, 1.8, 1.9, 2, 2.1, 2.2, 2.3, 2.4, 2.5,
            2.6, 2.7, 2.8, 2.9, 3, 3.1, 3.2, 3.3, 3.4, 3.5, 3.6, 3.7, 3.8,
            3.9, 4, 4.1, 4.2, 4.3, 4.4, 4.5, 4.6, 4.7, 4.8, 4.9, 5
        };

        private static readonly List<TestData> TestDataList = new()
        {
            new TestData(new ExponentialDistribution(),
                DefaultX,
                new[]
                {
                    1, 0.90483741803596, 0.818730753077982, 0.740818220681718, 
                    0.670320046035639, 0.606530659712633, 0.548811636094026, 0.496585303791409, 
                    0.449328964117222, 0.406569659740599, 0.367879441171442, 0.33287108369808, 
                    0.301194211912202, 0.272531793034013, 0.246596963941606, 0.22313016014843, 
                    0.201896517994655, 0.182683524052735, 0.165298888221587, 0.149568619222635, 
                    0.135335283236613, 0.122456428252982, 0.110803158362334, 0.100258843722804, 
                    0.0907179532894125, 0.0820849986238988, 0.0742735782143339, 0.0672055127397498, 
                    0.060810062625218, 0.0550232200564072, 0.0497870683678639, 0.0450492023935578, 
                    0.0407622039783662, 0.03688316740124, 0.0333732699603261, 0.0301973834223185, 
                    0.0273237224472926, 0.0247235264703394, 0.0223707718561656, 0.0202419114458044, 
                    0.0183156388887342, 0.0165726754017612, 0.0149955768204777, 0.0135685590122009, 
                    0.0122773399030684, 0.0111089965382423, 0.0100518357446336, 0.00909527710169582, 
                    0.00822974704902002, 0.00744658307092434, 0.00673794699908547
                },
                new[]
                {
                    0, 0.0951625819640404, 0.181269246922018, 0.259181779318282, 
                    0.329679953964361, 0.393469340287367, 0.451188363905974, 0.50341469620859, 
                    0.550671035882778, 0.593430340259401, 0.632120558828558, 0.667128916301921, 
                    0.698805788087798, 0.727468206965987, 0.753403036058394, 0.77686983985157, 
                    0.798103482005345, 0.817316475947265, 0.834701111778413, 0.850431380777365, 
                    0.864664716763387, 0.877543571747018, 0.889196841637666, 0.899741156277196, 
                    0.909282046710588, 0.917915001376101, 0.925726421785666, 0.93279448726025, 
                    0.939189937374782, 0.944976779943593, 0.950212931632136, 0.954950797606442, 
                    0.959237796021634, 0.96311683259876, 0.966626730039674, 0.969802616577682, 
                    0.972676277552707, 0.975276473529661, 0.977629228143834, 0.979758088554196, 
                    0.981684361111266, 0.983427324598239, 0.985004423179522, 0.986431440987799, 
                    0.987722660096932, 0.988891003461758, 0.989948164255366, 0.990904722898304, 
                    0.99177025295098, 0.992553416929076, 0.993262053000915
                },
                DefaultProbs,
                new[]
                {
                    0, 0.0100503358535014, 0.0202027073175194, 0.0304592074847085, 
                    0.0408219945202551, 0.0512932943875505, 0.0618754037180875, 0.0725706928348354, 
                    0.0833816089390511, 0.0943106794712413, 0.105360515657826, 0.116533816255952, 
                    0.127833371509885, 0.139262067333508, 0.150822889734584, 0.162518929497775, 
                    0.174353387144778, 0.186329578191493, 0.198450938723838, 0.210721031315653, 
                    0.22314355131421, 0.23572233352107, 0.2484613592985, 0.261364764134408, 
                    0.27443684570176, 0.287682072451781, 0.301105092783922, 0.3147107448397, 
                    0.328504066972036, 0.342490308946776, 0.356674943938732, 0.371063681390832, 
                    0.385662480811985, 0.400477566597125, 0.415515443961666, 0.430782916092454, 
                    0.446287102628419, 0.462035459596559, 0.478035800943, 0.49429632181478, 
                    0.510825623765991, 0.527632742082372, 0.544727175441672, 0.562118918153541, 
                    0.579818495252942, 0.59783700075562, 0.616186139423817, 0.63487827243597, 
                    0.653926467406664, 0.673344553263766, 0.693147180559945, 0.713349887877465, 
                    0.7339691750802, 0.755022584278033, 0.776528789498997, 0.798507696217772, 
                    0.82098055206983, 0.843970070294529, 0.867500567704723, 0.891598119283784, 
                    0.916290731874155, 0.941608539858445, 0.967584026261706, 0.994252273343867, 
                    1.02165124753198, 1.04982212449868, 1.07880966137193, 1.10866262452161, 
                    1.13943428318837, 1.17118298150295, 1.20397280432594, 1.23787435600162, 
                    1.27296567581289, 1.30933331998376, 1.34707364796661, 1.38629436111989, 
                    1.42711635564015, 1.46967597005894, 1.51412773262978, 1.56064774826467, 
                    1.6094379124341, 1.66073120682165, 1.71479842809193, 1.77195684193188, 
                    1.83258146374831, 1.89711998488588, 1.96611285637283, 2.04022082852655, 
                    2.12026353620009, 2.20727491318972, 2.30258509299405, 2.40794560865187, 
                    2.52572864430826, 2.65926003693278, 2.81341071676004, 2.99573227355399, 
                    3.2188758248682, 3.50655789731998, 3.91202300542815, 4.60517018598809, 
                    double.PositiveInfinity
                }),
            new TestData(new ExponentialDistribution(2),
                DefaultX,
                new[]
                {
                    2, 1.63746150615596, 1.34064009207128, 1.09762327218805, 0.898657928234443, 
                    0.735758882342885, 0.602388423824404, 0.493193927883213, 0.403793035989311, 
                    0.330597776443173, 0.270670566473225, 0.221606316724668, 0.181435906578825, 
                    0.148547156428668, 0.121620125250436, 0.0995741367357279, 0.0815244079567324, 
                    0.0667465399206521, 0.0546474448945851, 0.0447415437123312, 0.0366312777774684, 
                    0.0299911536409554, 0.0245546798061369, 0.0201036714892672, 0.01645949409804, 
                    0.0134758939981709, 0.0110331288415215, 0.00903316188522533, 
                    0.00739572743296586, 0.00605510949075163, 0.00495750435333272, 
                    0.00405886127259147, 0.00332311454634787, 0.00272073607509579, 
                    0.0022275502956896, 0.00182376393110903, 0.00149317161675336, 
                    0.00122250552225914, 0.00100090286688122, 0.000819469957959573, 
                    0.000670925255805024, 0.000549307139944284, 0.000449734648357696, 
                    0.000368211587335158, 0.000301466150190953, 0.000246819608173359, 
                    0.000202078803674186, 0.000165448131113264, 0.000135457472981708, 
                    0.000110903198864354, 9.07998595249697e-05
                },
                new[]
                {
                    0, 0.181269246922018, 0.329679953964361, 0.451188363905974, 
                    0.550671035882778, 0.632120558828558, 0.698805788087798, 0.753403036058394, 
                    0.798103482005345, 0.834701111778413, 0.864664716763387, 0.889196841637666, 
                    0.909282046710588, 0.925726421785666, 0.939189937374782, 0.950212931632136, 
                    0.959237796021634, 0.966626730039674, 0.972676277552707, 0.977629228143834, 
                    0.981684361111266, 0.985004423179522, 0.987722660096932, 0.989948164255366, 
                    0.99177025295098, 0.993262053000915, 0.994483435579239, 0.995483419057387, 
                    0.996302136283517, 0.996972445254624, 0.997521247823334, 0.997970569363704, 
                    0.998338442726826, 0.998639631962452, 0.998886224852155, 0.999088118034446, 
                    0.999253414191623, 0.99938874723887, 0.999499548566559, 0.99959026502102, 
                    0.999664537372097, 0.999725346430028, 0.999775132675821, 0.999815894206332, 
                    0.999849266924905, 0.999876590195913, 0.999898960598163, 0.999917275934443, 
                    0.999932271263509, 0.999944548400568, 0.999954600070238
                },
                DefaultProbs,
                new[]
                {
                    0, 0.00502516792675072, 0.0101013536587597, 0.0152296037423543, 
                    0.0204109972601276, 0.0256466471937753, 0.0309377018590437, 0.0362853464174177, 
                    0.0416908044695255, 0.0471553397356207, 0.0526802578289132, 0.0582669081279758, 
                    0.0639166857549424, 0.0696310336667538, 0.0754114448672918, 0.0812594647488875, 
                    0.0871766935723889, 0.0931647890957467, 0.0992254693619191, 0.105360515657826, 
                    0.111571775657105, 0.117861166760535, 0.12423067964925, 0.130682382067204, 
                    0.13721842285088, 0.14384103622589, 0.150552546391961, 0.15735537241985, 
                    0.164252033486018, 0.171245154473388, 0.178337471969366, 0.185531840695416, 
                    0.192831240405992, 0.200238783298563, 0.207757721980833, 0.215391458046227, 
                    0.22314355131421, 0.231017729798279, 0.2390179004715, 0.24714816090739, 
                    0.255412811882995, 0.263816371041186, 0.272363587720836, 0.281059459076771, 
                    0.289909247626471, 0.29891850037781, 0.308093069711909, 0.317439136217985, 
                    0.326963233703332, 0.336672276631883, 0.346573590279973, 0.356674943938732, 
                    0.3669845875401, 0.377511292139016, 0.388264394749498, 0.399253848108886, 
                    0.410490276034915, 0.421985035147265, 0.433750283852361, 0.445799059641892, 
                    0.458145365937077, 0.470804269929222, 0.483792013130853, 0.497126136671934, 
                    0.510825623765991, 0.524911062249339, 0.539404830685965, 0.554331312260806, 
                    0.569717141594183, 0.585591490751473, 0.601986402162968, 0.618937178000809, 
                    0.636482837906444, 0.654666659991881, 0.673536823983305, 0.693147180559945, 
                    0.713558177820073, 0.734837985029471, 0.757063866314888, 0.780323874132334, 
                    0.80471895621705, 0.830365603410826, 0.857399214045964, 0.885978420965938, 
                    0.916290731874155, 0.948559992442941, 0.983056428186416, 1.02011041426328, 
                    1.06013176810005, 1.10363745659486, 1.15129254649702, 1.20397280432594, 
                    1.26286432215413, 1.32963001846639, 1.40670535838002, 1.497866136777, 
                    1.6094379124341, 1.75327894865999, 1.95601150271407, 2.30258509299405, 
                    double.PositiveInfinity
                })
        };

        [UsedImplicitly]
        public static TheoryData<string> TestDataKeys = TheoryDataHelper.Create(TestDataList.Select(it => it.Distribution.ToString()));

        [Theory]
        [MemberData(nameof(TestDataKeys))]
        public void ExponentialDistributionTest([NotNull] string testKey)
        {
            Check(TestDataList.First(it => it.Distribution.ToString() == testKey));
        }
    }
}