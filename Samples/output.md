## パブリック プレビュー: Azure Monitor の基本ログ、アーカイブ、復元、および検索ジョブ
* 対象
  * Azure Monitor

<br/>

* 内容
  * Azure Monitor Logs のパブリック プレビュー機能は、4 つの新しい Azure リージョン (US Virgina Gov、US Arizona Gov、China East 3、China North 3) で利用できるようになりました。
  * パブリック プレビュー機能は次のとおりです。
    1. 基本的なログ プラン: [ログ分析ワークスペースの概要 - Azure Monitor |Microsoft Docs](https://docs.microsoft.com/en-us/azure/azure-monitor/logs/log-analytics-workspace-overview#log-data-plans-preview)
    1. アーカイブ: [Azure モニター ログでデータ保持とアーカイブを構成する (プレビュー) - Azure モニター |Microsoft Docs](https://docs.microsoft.com/en-us/azure/azure-monitor/logs/data-retention-archive?tabs=portal-1%2Cportal-2)
    1. ジョブの検索: [Azure モニターでジョブを検索する (プレビュー) - Azure モニター |Microsoft Docs](https://docs.microsoft.com/en-us/azure/azure-monitor/logs/search-jobs?tabs=api-1%2Capi-2%2Capi-3)
    1. 復元: [Azure モニターでログを復元する (プレビュー) - Azure モニター |Microsoft Docs](https://docs.microsoft.com/en-us/azure/azure-monitor/logs/restore?tabs=api-1%2Capi-2)

<br/>

* 参考
  * Public preview: Azure Monitor basic logs, archive, restore and search jobs
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-azure-monitor-basic-logs-archive-restore-and-search-jobs/](https://azure.microsoft.com/ja-jp/updates/public-preview-azure-monitor-basic-logs-archive-restore-and-search-jobs/)

---

## パブリック プレビュー: マネージド ID ベースの認証を使用して、Azure Monitor コンテナーの分析情報を有効にする
* 対象
  * Azure Monitor

<br/>

* 内容
  * コンテナー インサイトは、AKS クラスターと Arc 対応クラスターの [Azure Monitor エージェントとの統合](https://docs.microsoft.com/en-us/azure/azure-monitor/containers/container-insights-onboard#azure-monitor-agent) をサポートするようになりました。この統合は、AKS および Arc 対応クラスターの Linux ノードで一般公開されました。この特殊なエージェントは、クラスター内のすべてのノードからパフォーマンスとイベント データを収集し、デプロイ中にエージェントが自動的にデプロイされ、指定されたログ分析ワークスペースに登録されます。
  * Azure Monitor エージェントでは、コンテナー インサイトは、AKS および Arc 対応クラスターのマネージド ID を使用した認証もサポートします。これは、監視エージェントがクラスターのマネージド ID を使用して Azure Monitor にデータを送信する、安全で簡略化された認証モデルです。既存の従来の証明書ベースのローカル認証を置き換え、クラスターにモニター・メトリック・パブリッシャーの役割を追加する必要がなくなります。システム割り当て ID とユーザー割り当て ID がサポートされています。
  * 詳細情報：
  * [変更点](https://docs.microsoft.com/en-us/azure/azure-monitor/containers/container-insights-onboard#authentication)
  * [コンテナー分析情報のために、既存の AKS クラスターをマネージド ID 認証に移行する方法](https://docs.microsoft.com/en-us/azure/azure-monitor/containers/container-insights-enable-existing-clusters?tabs=azure-cli#migrate-to-managed-identity-authentication)
  * [Arc 対応クラスターをコンテナー分析情報の管理対象 ID 認証に移行する方法](https://docs.microsoft.com/en-us/azure/azure-monitor/containers/container-insights-enable-arc-enabled-clusters?tabs=create-cli%2Cverify-portal%2Cmigrate-cli#migrate-to-managed-identity-authentication-preview)

<br/>

* 参考
  * Public preview: Use managed identity-based authentication to enable Azure Monitor container insights
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-use-managed-identitybased-authentication-to-enable-azure-monitor-container-insights/](https://azure.microsoft.com/ja-jp/updates/public-preview-use-managed-identitybased-authentication-to-enable-azure-monitor-container-insights/)

---

## パブリック プレビュー: アプリ構成の geo レプリケーションのサポート
* 対象
  * App Configuration

<br/>

* 内容
  * Azure アプリ構成では、構成ストア内の構成データを他の Azure リージョンのレプリカにレプリケートできるようになりました。Standard レベルのサブスクライバーが使用できる、構成ストアまたはレプリカ内のキー/値に対する更新または追加は、最終的な整合性モデルを使用して自動的に同期されます。これにより、次のような利点があります。
    * 回復性の向上 – リージョン間でのレプリケーションは、サービスの停止がストアまたはレプリカのいずれかに影響を与えた場合でも、構成データに引き続きアクセスできることを意味します。
    * 待機時間の最小化 – アプリケーションは、クロスリージョン要求を発行するのではなく、ローカルでデータを消費できるようになりました。
    * 要求の配布の最適化 – レプリカと構成ストアには固有の適用可能な要求制限があるため、要求を効率的に配布して、レプリカまたは構成ストアの要求制限が使い果たされるのを防ぐことができます。
  * [詳細](https://docs.microsoft.com/azure/azure-app-configuration/concept-geo-replication)。
  * [geo レプリケーションを有効にする方法](https://docs.microsoft.com/en-us/azure/azure-app-configuration/howto-geo-replication)。

<br/>

* 参考
  * Public preview: App Configuration geo replication support 
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-app-configuration-geo-replication-support/](https://azure.microsoft.com/ja-jp/updates/public-preview-app-configuration-geo-replication-support/)

---

## パブリック プレビュー: Arc 対応 SQL MI 用の S3 互換ストレージを使用したバックアップ データベース
* 対象
  * Azure Arc 対応データ サービス

<br/>

* 内容
  * Azure Arc 対応マネージド インスタンスは、S3 互換のオブジェクト ストレージをバックアップおよび復元先としてサポートするようになりました。SQL Server 2022 (16.x) プレビューでは、データ プラットフォームへのオブジェクト ストレージの統合が導入され、Azure Storage に加えて SQL Server を S3 互換のオブジェクト ストレージと統合できます。この統合を提供するために、SQL Server は新しい S3 コネクタで拡張され、S3 REST API を使用して S3 互換オブジェクト ストレージの任意のプロバイダーに接続します。SQL Server 2022 (16.x) プレビューでは、REST API を使用した新しい S3 コネクタのサポートを追加することで、既存の BACKUP/RESTORE TO/FROM URL 構文が拡張されています。
  * [詳細](https://docs.microsoft.com/en-us/azure/azure-arc/data/release-notes)。

<br/>

* 参考
  * Public preview: Backup database with S3-compatible storage for Arc-enabled SQL MI
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-backup-database-with-s3compatible-storage-for-arcenabled-sql-mi/](https://azure.microsoft.com/ja-jp/updates/public-preview-backup-database-with-s3compatible-storage-for-arcenabled-sql-mi/)

---

## 一般提供: Azure Cache for Redis Enterprise の予約インスタンス価格
* 対象
  * Azure Cache for Redis

<br/>

* 内容
  * [予約インスタンス](https://azure.microsoft.com/reservations/)を購入することで、Azure Cache for Redis のエンタープライズ レベルとエンタープライズ フラッシュ レベルの使用量を最大 55% 節約できます。予約割引は、一致するキャッシュリソースに自動的に適用されるため、予約の購入プロセスが合理化されます。予約は、最大35%の割引で1年単位、または55%の割引で3年単位で利用できます。これは、Azure デプロイのコスト効率を最大化し、最良の取引を確実に得るための優れた方法です。
  * [リザーブドインスタンスの購入]詳細については、Azure portal から (https://ms.portal.azure.com/#view/Microsoft_Azure_Reservations/CreateBlade/referrer/acmblg) を今すぐ入手するか、[ドキュメント](https://docs.microsoft.com/azure/cost 管理課金/予約/保存コンピューティング コスト予約) をお読みください。

<br/>

* 参考
  * General availability: Reserved instance pricing for Azure Cache for Redis Enterprise 
    * [https://azure.microsoft.com/ja-jp/updates/general-availability-reserved-instance-pricing-for-azure-cache-for-redis-enterprise/](https://azure.microsoft.com/ja-jp/updates/general-availability-reserved-instance-pricing-for-azure-cache-for-redis-enterprise/)

---

## 一般提供: Azure Database for MySQL のサーバー ログ - フレキシブル サーバー
* 対象
  * Azure Database for MySQL
  * Open Source

<br/>

* 内容
  * Azure Database for MySQL のサーバー ログを使用する - フレキシブル サーバーを使用して、サーバーのログ記録を有効にし、結果をファイルに保存します。サーバー・ログを有効にしてログ・タイプを選択すると、サーバーからログをダウンロードできます。これらのログの情報を使用して、サーバーで実行されたアクティビティに関する詳細な分析情報を取得し、潜在的な問題を特定してトラブルシューティングします。
  * [詳細](https://go.microsoft.com/fwlink/?linkid=2200106)。

<br/>

* 参考
  * General availability: Server logs for Azure Database for MySQL - Flexible Server 
    * [https://azure.microsoft.com/ja-jp/updates/general-availability-server-logs-for-azure-database-for-mysql-flexible-server/](https://azure.microsoft.com/ja-jp/updates/general-availability-server-logs-for-azure-database-for-mysql-flexible-server/)

---

## パブリック プレビュー: Azure Database for PostgreSQL
* 対象
  * Azure Database for PostgreSQL
  * Pricing & Offerings
  * Open Source

<br/>

* 内容
  * PostgreSQL のマイナー バージョン 11.17、12.12、13.8、および 14.5 は、Azure Database for PostgreSQL — Hyperscale (Citus) でサポートされるようになりました。この新しいサポートには、複数のバグ修正とマイナーな改善が含まれています。これらの新しいマイナー バージョンは、新しく作成されたすべての Azure Database for PostgreSQL ハイパースケール (Citus) サーバー グループですぐに利用でき、既存のサーバー グループへの次回の定期メンテナンスの一部として提供されます。
  * [詳細](https://docs.microsoft.com/azure/postgresql/concepts-hyperscale-versions#postgresql-versions)。

<br/>

* 参考
  * Public preview: Azure Database for PostgreSQL
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-azure-database-for-postgresql/](https://azure.microsoft.com/ja-jp/updates/public-preview-azure-database-for-postgresql/)

---

## Azure Machine Learning — 2022 年 8 月のパブリック プレビュー更新プログラム
* 対象
  * Azure Machine Learning

<br/>

* 内容
  * [**自動 ML コード生成**](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-generate-automl-training-code) は、表形式、画像、テキスト データにわたる 10 個の AutoML タスクすべてで使用できるようになりました。この機能により、AutoML でトレーニングされたモデルを選択し、デプロイ前に探索、カスタマイズ、および再トレーニングを行う Python トレーニング コードを生成できるため、AutoML は透過的なソリューションになります。
  * [**パイプライン内の自動 ML**](https://docs.microsoft.com/en-us/azure/machine-learning/how-to-figure-auto-train#automl-in-pipelines)****MLOps プロセスで AutoML のパワーを最大限に活用できます。 データを準備し、AutoML にファネルし、結果として得られる最適なモデルを登録し、1 つのパイプライン内ですべてをスコアリングするためのエンドポイントを設定できます。****

<br/>

* 参考
  * Azure Machine Learning—Public preview updates for August 2022
    * [https://azure.microsoft.com/ja-jp/updates/azure-machine-learning-public-preview-updates-for-august-2022/](https://azure.microsoft.com/ja-jp/updates/azure-machine-learning-public-preview-updates-for-august-2022/)

---

## 一般提供: Azure Machine Learning の階層予測
* 対象
  * Azure Machine Learning

<br/>

* 内容
  * [**階層予測**](https://github.com/Azure/azureml-examples/blob/main/python-sdk/tutorials/automl-with-azureml/forecasting-hierarchical-timeseries/auto-ml-forecasting-hierarchical-timeseries.ipynb) を使用すると、階層データの予測を生成するために個々のモデルを手動で作成する必要がなくなり、階層のすべてのレベルで階層認識型で一貫性のある予測を生成することができます。

<br/>

* 参考
  * Generally available: Hierarchical forecasting for Azure Machine Learning
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-hierarchical-forecasting-for-azure-machine-learning/](https://azure.microsoft.com/ja-jp/updates/generally-available-hierarchical-forecasting-for-azure-machine-learning/)

---

## Azure SQL - 2022 年 8 月中旬の一般提供更新プログラム
* 対象
  * Azure SQL Database

<br/>

* 内容
  * **Azure SQL - 2022 年 8 月中旬の一般提供更新プログラム**
  * 2022 年 8 月中旬に、Azure SQL に対して次の更新と機能強化が行われました。
    * [Azure Active Directory と Kerberos を使用した Azure SQL マネージド インスタンスの Windows 認証のセットアップ](https://aka.ms/WinauthAADSQLMIGA)。

<br/>

* 参考
  * Azure SQL—General availability updates for mid-August 2022
    * [https://azure.microsoft.com/ja-jp/updates/azure-sql-general-availability-updates-for-midaugust-2022/](https://azure.microsoft.com/ja-jp/updates/azure-sql-general-availability-updates-for-midaugust-2022/)

---

## パブリック プレビュー: Microsoft Azure 負荷テストはプライベート エンドポイント テストをサポートしています。
* 対象
  * Azure Load Testing

<br/>

* 内容
  * Azure Load Testing が [プライベート エンドポイントのロード テスト](https://aka.ms/MALT/Private エンドポイント) をサポートするようになりました。Azure 負荷テスト リソースを作成し、仮想ネットワーク (VNET インジェクション) 内から負荷を生成できるようにすることができます。
  * この機能により、次の [使用シナリオ](https://aka.ms/MALT/VNETscenarios) が可能になります。
    * Azure 仮想ネットワークにデプロイされたエンドポイントへの負荷の生成
    * クライアント IP アドレスの制限など、アクセス制限のあるパブリック エンドポイントへの負荷の生成
    * パブリックにアクセスできないオンプレミス サービスに負荷を生成し、ExpressRoute 経由で Azure に接続する
  * この機能は、オーストラリア東部、米国東部、米国東部 2、および北ヨーロッパの Azure リージョンで利用できます。これはまもなく米国中南部と米国西部2で利用可能になります。

<br/>

* 参考
  * Public preview: Microsoft Azure Load Testing supports private endpoints testing
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-microsoft-azure-load-testing-supports-private-endpoints-testing/](https://azure.microsoft.com/ja-jp/updates/public-preview-microsoft-azure-load-testing-supports-private-endpoints-testing/)

---

## 一般提供: プライベート エンドポイントのユーザー定義ルートのサポート
* 対象
  * Azure Private Link
  * Virtual Network

<br/>

* 内容
  * プライベート エンドポイントのユーザー定義ルート (UDR) サポートが一般公開されました。この機能強化により、カスタム ルートを定義するときに /32 住所プレフィックスを作成する必要がなくなります。これで、ネットワーク仮想アプライアンス(NVA)を介してプライベート エンドポイント(PE)宛てのトラフィックに対して、ユーザー定義のルート テーブルでより広いアドレス プレフィックスを使用できるようになりました。この機能を利用するには、**PrivateEndpointNetworkPolicies** と呼ばれる特定のサブネット レベルのプロパティを、プライベート エンドポイント リソースを含むサブネットで有効に設定する必要があります。
  * **地域の可用性:**
  * この機能は、現時点では次の地域で利用できるようになります。
  * **米国東部、米国西部、米国北部、米国南部、米国中部、米国東部2、ヨーロッパ北部、ヨーロッパ西部、アジア東部、アジア南東部、東日本、西日本、ブラジル南部、オーストラリア東部、オーストラリア南東部、インド中部、インド南部、カナダ中部、カナダ東部、米国西部2、米国西部中部、英国西部、英国南部、韓国南部、韓国中部、フランス南部、 フランス中部、オーストラリア中部、南アフリカ北部、アラブ首長国連邦中部、アラブ首長国連邦北部、スイス北部、スイス西部、ドイツ北部、ドイツ西部、ノルウェー東部、ノルウェー西部、米国西部3、ジオインド中部、ジオインド西部**、**スウェーデン南部、スウェーデン中部、カタール中部、米国中部早期更新アクセスプログラム、米国東部2早期更新アクセスプログラム**。
  * **プライベートエンドポイントネットワークポリシーの管理:**
  * [プライベート エンドポイントのネットワーク ポリシーの管理 - Azure プライベート リンク |Microsoft Docs](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fprivate-link%2Fdisable-private-endpoint-network-policy&amp;data=05%7C01%7CSumeet.Mittal%40microsoft.com%7C787aa8a2b4e4462f256f08da80666ff4%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C6379634747704654854%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&amp;sdata=sd9qfc2f1G1tVjpYXVDt8%2BM2mzR2J7UXFosqG0CGp9Q%3D&amp;reserved=0)
  * **ユーザー定義ルートの概要:**
  * [Azure 仮想ネットワーク トラフィック ルーティング |Microsoft Docs](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fvirtual-network%2Fvirtual-networks-udr-overview&amp;data=05%7C01%7CSumeet.Mittal%40microsoft.com%7C787aa8a2b4e4462f256f08da80666ff4%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C6379634747704654854%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&amp;sdata=suZ8i2G%2FiVdtBd6NGo%2FfNOZdOIG9Ry%2FAvWCVE83D6dg%3D&amp;reserved=0)
  * **どのように動作するか:**
  * [ネットワーク トラフィックのルーティング - チュートリアル - Azure ポータル |Microsoft Docs](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fvirtual-network%2Ftutorial-create-route-table-portal&amp;data=05%7C01%7CSumeet.Mittal%40microsoft.com%7C787aa8a2b4e4462f256f08da80666ff4%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C6379634747704654854%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&amp;sdata=i0c9h7E14X0W%2B%2BZk4mMkGdvjOhG0of5thZuyKrQDc1I%3D&amp;reserved=0)
  * [Azure ルート テーブルの作成、変更、または削除|Microsoft Docs](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fvirtual-network%2Fmanage-route-table&amp;data=05%7C01%7CSumeet.Mittal%40microsoft.com%7C787aa8a2b4e4462f256f08da80666ff4%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C6379634747704654854%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&amp;sdata=GPZ4qIi1FsOL0YUqTWtbitmsb6jxWdt6Mkjq4xkaces%3D&amp;reserved=0)
  * **プライベートリンクとは何ですか:**
  * [Azure Private Link とは何ですか?|Microsoft Docs](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fprivate-link%2Fprivate-link-overview&amp;data=05%7C01%7CSumeet.Mittal%40microsoft.com%7C787aa8a2b4e4462f256f08da80666ff4%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C6379634747704654854%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTi6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C%7C&amp;sdata=2Y0nBe5kszgx8hmlhCbQza%2BNsAM2iRKRjZLcikG5WtU%3D&amp;reserved=0)
  * 

<br/>

* 参考
  * General availability: User-defined routes support for private endpoints
    * [https://azure.microsoft.com/ja-jp/updates/general-availability-of-user-defined-routes-support-for-private-endpoints/](https://azure.microsoft.com/ja-jp/updates/general-availability-of-user-defined-routes-support-for-private-endpoints/)

---

## 一般提供: プライベート エンドポイントのサポート ネットワーク セキュリティ グループ
* 対象
  * Azure Private Link
  * Virtual Network

<br/>

* 内容
  * プライベート エンドポイントのネットワーク セキュリティ グループ (NSG) サポートが一般公開されました。この機能強化により、プライベート エンドポイント宛てのトラフィックに対して高度なセキュリティ制御を有効にすることができます。この機能を利用するには、**PrivateEndpointNetworkPolicies** と呼ばれる特定のサブネット レベルのプロパティを、プライベート エンドポイント リソースを含むサブネットで有効に設定する必要があります。
  * 現時点では、プライベート リンク ネットワーク セキュリティ グループのサポートは、ほとんどのパブリック リージョンで利用できます。
  * **地域の可用性:**
  * この機能は、現時点では次の地域で利用できるようになります。
  * **米国東部、米国西部、米国北部、米国南部、米国中部、米国東部2、ヨーロッパ北部、ヨーロッパ西部、アジア東部、アジア南東部、東日本、西日本、ブラジル南部、オーストラリア東部、オーストラリア南東部、インド中部、インド南部、カナダ中部、カナダ東部、米国西部2、米国西部中部、英国西部、英国南部、韓国南部、韓国中部、フランス南部、 フランス中部、オーストラリア中部、南アフリカ北部、アラブ首長国連邦中部、アラブ首長国連邦北部、スイス北部、スイス西部、ドイツ北部、ドイツ西部、ノルウェー東部、ノルウェー西部、米国西部3、ジオインド中部、ジオインド西部**、**スウェーデン南部、スウェーデン中部、カタール中部、米国中部早期更新アクセスプログラム、米国東部2早期更新アクセスプログラム**
  * **プライベートエンドポイントネットワークポリシーの管理:**
  * [プライベート エンドポイントのネットワーク ポリシーの管理 - Azure プライベート リンク |Microsoft Docs](https://docs.microsoft.com/en-us/azure/private-link/disable-private-endpoint-network-policy)
  * **ネットワーク セキュリティ グループの概要:**
  * [Azure ネットワーク セキュリティ グループの概要|Microsoft Docs](https://docs.microsoft.com/en-us/azure/virtual-network/network-security-groups-overview)
  * **どのように動作するか:**
  * [ネットワークセキュリティグループ - どのように動作する|Microsoft Docs](https://docs.microsoft.com/en-us/azure/virtual-network/network-security-group-how-it-works)
  * **プライベートリンクとは何ですか:**
  * [Azure Private Link とは何ですか?|Microsoft Docs](https://docs.microsoft.com/en-us/azure/private-link/private-link-overview)

<br/>

* 参考
  * General availability: Network security groups support for private endpoints
    * [https://azure.microsoft.com/ja-jp/updates/general-availability-of-network-security-groups-support-for-private-endpoints/](https://azure.microsoft.com/ja-jp/updates/general-availability-of-network-security-groups-support-for-private-endpoints/)

---

## 一般提供: JetStream DR for AVS は Azure NetApp Files データストアをサポートしています。
* 対象
  * Azure NetApp Files

<br/>

* 内容
  * クラウドへのディザスターリカバリは、サイトの停止やランサムウェアなどのデータ破損イベントからワークロードを保護する回復力があり、費用対効果の高い方法です。VMware VAIO フレームワークを活用することで、オンプレミスの VMware ワークロードを Azure Blob ストレージにレプリケートし、データ損失を最小限に抑えたり、ほぼゼロに近い目標復旧時間 (RTO) で復旧したりできます。[JetStream Disaster Recovert (DR) は、オンプレミスから Azure VMware Solution にレプリケートされたワークロードをシームレスに回復できます](https://azure.microsoft.com/updates/jetstream-disaster-recovery-for-azure-vmware-solution-now-generally-available/)。JetStream DRは、災害復旧サイトで最小限のリソースを消費し、費用対効果の高いクラウドストレージを使用することにより、費用対効果の高い災害復旧を可能にします。
  * [JetStream DR は、Azure NetApp Files データ ストアへのレプリケーションと復旧の自動化もできます](https://docs.microsoft.com/azure/azure-vmware/deploy-disaster-recovery-using-jetstream#disaster-recovery-with-azure-netapp-files-jetstream-dr-and-azure-vmware-solution)。Runbook の設定に従って、独立した VM または関連する VM のグループを回復サイト インフラストラクチャに回復できます。また、ランサムウェア保護のためのポイントインタイムリカバリも提供します。

<br/>

* 参考
  * Generally available: JetStream DR for AVS supports Azure NetApp Files datastores
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-jetstream-disaster-recovery-for-azure-vmware-solution-now-supports-azure-netapp-files-datastores/](https://azure.microsoft.com/ja-jp/updates/generally-available-jetstream-disaster-recovery-for-azure-vmware-solution-now-supports-azure-netapp-files-datastores/)

---

## 一般提供開始: Azure VMware Solution がスウェーデン中部で利用可能になりました
* 対象
  * Azure VMware Solution
  * Regions & Datacenters

<br/>

* 内容
  * Azure VMware ソリューションを使用すると、アプリケーションの再設計や操作の再構築に伴うコスト、労力、またはリスクなしに、既存のオンプレミスの VMware ワークロードをシームレスに拡張または移行できます。この更新プログラムにより、Azure VMware Solution はスウェーデンの中央 Azure リージョンに可用性を拡大しました。
  * Azure VMware Solution は以下をサポートします。
    * VMware環境の運用上の一貫性を維持しながら、データ・センターを終了します。
    * オンプレミスVMware環境向けのビジネス継続性と災害復旧。
    * VMware ベースのワークロードの Azure への迅速なクラウド移行。
    * オンプレミスとクラウドベースの VMware vSphere 環境をハイブリッドにします。
  * 現在および今後のリージョンの可用性に関する最新情報については、[地域別の製品ページをご覧ください。(https://azure.microsoft.com/en-us/global-infrastructure/services/)
  * ソリューションの詳細については、以下を参照してください。
    * [Azure VMware Solution Webサイト](https://azure.microsoft.com/en-us/services/azure-vmware)および[ドキュメント](https://docs.microsoft.com/en-us/azure/azure-vmware)をご覧ください。
    * [Azure VMware Solution の価格設定](https://azure.microsoft.com/en-us/ppriceing/details/azure-vmware/)を確認してください。

<br/>

* 参考
  * Generally available: Azure VMware Solution now in Sweden Central
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-azure-vmware-solution-now-in-sweden-central/](https://azure.microsoft.com/ja-jp/updates/generally-available-azure-vmware-solution-now-in-sweden-central/)

---

## 一般提供: vRealize Log Insight Cloud と Azure VMware Solution の統合
* 対象
  * Azure VMware Solution

<br/>

* 内容
  * vRealize Log Insights Cloud with Azure VMware Solution のサポートが、すべてのお客様に一般公開されました。
  * vRLI-C は、次の機能を提供します。
    * 一元化されたログ管理
    * 運用上の深い可視性
    * インテリジェントな分析
    * トラブルシューティングとセキュリティの向上
  * vRealize Log Insight Cloud と Azure VMware Solution の統合により、IT 組織の運用効率が向上し、予期しないダウンタイムから生じるコストが軽減され、セキュリティ関連のイベントが可視化され、組織のリスクが軽減されます。
  * ログには、戦略的な意思決定、リアルタイムのトラブルシューティング、監査、およびセキュリティのためにビジネスが必要とする可能性のあるすべての情報が含まれています。ただし、企業は環境内の何千ものオブジェクトを監視する必要があり、それぞれが数千または数百万のログを生成する場合があります。その量のデータの中から適切なデータを大規模に見つけようとするのは、非常に複雑で時間がかかります。
  * マシンで生成されたデータの規模は、企業がインフラストラクチャにまたがり、物理、仮想、およびマルチクラウド環境にわたってアプリケーションを拡張するにつれて増加するだけです。企業は、コラボレーション、継続的インテグレーション、デリバリー(CI/CD)を向上させるためにDevOpsの考え方を採用し、古くてレガシーなアプリケーション開発方法を混乱させています。
  * vRealize Log Insights Cloud を使用すると、30 日間のデータ保持で 15 GB/日のログ取り込みまでの無料試用版制限を取得できます。試用期間が終了すると、インデックス パーティションと非インデックス パーティションが選択できる可変データ保持期間を持つ複数のサブスクリプション オプションが存在します。
  * まだサインインしていない場合は、サインインして vRealize Log Insight Cloud 試用版 [体験版](https://www.vmware.com/products/vrealize-log-insight.html#logiq_service_request_access_form) を開始してください。独自のvRealize Log Insight Cloudインスタンスをスピンアップし、AVS syslogの取り込みを開始できます。
  * ユースケースの概要を説明するのに役立つコンテンツ:
    * eBook – [Unified Log Visibility, Design for DevOps](https://www.vmware.com/content/dam/digitalmarketing/vmware/en/pdf/docs/vmw-vrlic-unified-log-visibility-ebook.pdf)
    * インフォグラフィック – [Log Management at the Speed of DevOps](https://www.vmware.com/content/dam/digitalmarketing/vmware/en/pdf/docs/vmw-vrealize-log-insight-cloud-devops-infographic.pdf)
    * ポッドキャスト – [vRealize Log Insight Cloudでログ分析を再考する](https://nam04.safelinks.protection.outlook.com/?url=https%3A%2F%2Fpacketpushers.net%2Fpodcast%2Fday-two-cloud-138-rethinking-logs-and-analysis-with-vrealize-log-insight-cloud-sponsored%2F&amp;data=04%7C01%7Cphamda%40vmware.com%7C2e0c353860574ba18c8808da07ad4f97%7Cb39138ca3cee4b4aa4d6cd83d9d62f0%7C0%7C0%7C0%7C637830738202735938%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000&amp;sdata=bhkd8XtgcIW884baZqAXQIFriW9UYlXwARhVOGM8%2Fn4%3D&amp;reserved=0)

<br/>

* 参考
  * Generally available: vRealize Log Insight Cloud with Azure VMware Solution integration
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-vrealize-log-insight-cloud-with-azure-vmware-solution-integration/](https://azure.microsoft.com/ja-jp/updates/generally-available-vrealize-log-insight-cloud-with-azure-vmware-solution-integration/)

---

## 一般提供: Azure VMware ソリューションのパブリック IP 機能
* 対象
  * Azure VMware Solution

<br/>

* 内容
  * 本日、Azure VMware ソリューションの新しいパブリック IP 機能の一般提供開始を発表しました。Azure VMware ソリューションで実行されているほとんどのお客様のアプリケーションでは、インターネット アクセスが必要です。これらのアプリケーションには、アウトバウンドとインバウンドの両方のインターネット接続が必要です。Azure VMware ソリューション パブリック IP は、これらのアプリケーションを実行するための簡略化されたスケーラブルなソリューションです。この機能により、以下が可能になります。
    * AVSのインバウンドおよびアウトバウンドインターネットアクセスをNSX-Tエッジに直接アクセスします。
    * 最大 1000 以上のパブリック IP を受信する機能。
    * インターネットに出入りするネットワークトラフィックに対するDDoSセキュリティ保護。
    * パブリック インターネット経由での VMware HCX (VMware VM の移行ツール) のサポートを有効にします。
  * この統合ソリューションの地域別可用性には、次のものが含まれます。オーストラリア東部、オーストラリア南部、ブラジル南部、カナダ中部、カナダ東部、東アジア、米国東部、米国東部2、ドイツ西部、日本東部、米国中北部、北ヨーロッパ、南アフリカ、スウェーデン中部、英国南部、英国西部、米国中西部、米国西部
  * この機能により、Azure VMware ソリューションのプライベート クラウド上のリソースへの受信および送信インターネット アクセスを作成するための 3 つの主要なパターンが作成されました。各オプションの詳細については、[AVS のインターネット接続設計に関する考慮事項](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fazure-vmware%2Fconcepts-design-public-internet-access&amp;data=05%7C01%7Cyashbhamare%40microsoft.com%7Cfae7d2c471df4ca8b04808da43ef9707%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C0%7C637896993758692533%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTiI6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C&amp;sdata=sS1WzrxhrA5rVLTocMSnhL%2F4kG9TR0uqWesASMHz9vg%3D&amp;reserved=0) Azure VMware Solution ドキュメント Web サイトにあります。パブリック IP を NSX エッジまで構成する方法については、[Azure VMware ソリューションでパブリック IP を NSX エッジに有効にする](https://nam06.safelinks.protection.outlook.com/?url=https%3A%2F%2Fdocs.microsoft.com%2Fen-us%2Fazure%2Fazure-vmware%2Fenable-public-ip-nsx-edge&amp;data=05%7C01%7Cyashbhamare%40microsoft] を参照してください。com%7Cfae7d2c471df4ca8b04808da43ef9707%7C72f988bf86f141af91ab2d7cd011db47%7C1%7C0%7C637896993758692533%7CUnknown%7CTWFpbGZsb3d8eyJWIjoiMC4wLjAwMDAiLCJQIjoiV2luMzIiLCJBTi6Ik1haWwiLCJXVCI6Mn0%3D%7C3000%7C%7C&amp;sdata=4Z7GuHhu247G%2Fd%2BN4j1ddwT3BmVlcNgsw9Oeun14NbA%3D&amp;reserved=0).
  * 利用可能な機能の詳細については、[Azure VMware Solution](https://docs.microsoft.com/en-us/azure/azure-vmware/) ドキュメント Web ページを参照してください。

<br/>

* 参考
  * Generally available: Public IP Capability for Azure VMware Solution
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-public-ip-capability-for-azure-vmware-solution/](https://azure.microsoft.com/ja-jp/updates/generally-available-public-ip-capability-for-azure-vmware-solution/)

---

## パブリック プレビュー: Event Hubs のコード エディターを使用しない 4 つの新機能
* 対象
  * Azure Stream Analytics

<br/>

* 内容
  * Azure Stream Analytics を使用して、Azure Event Hubs でリアルタイム データ ストリームを処理します。コード エディターを使用しないと、1 行のコードを記述することなく、Stream Analytics ジョブを簡単に開発できます。数分以内に、多くのシナリオに取り組むジョブを開発して実行できます。
  * ジョブの構築と監視に役立つ 4 つの新機能があります。
    1. **マネージド ID**: Event Hub ストリーミング入力、Cosmos DB ストリーミング出力、および Azure Data Lake Storage Gen2 で認証モードとして "マネージド ID" を使用できるようになりました。マネージド ID により、パスワードの変更や 90 日ごとに発生するユーザー トークンの有効期限による再認証の必要性など、ユーザー ベースの認証方法の制限がなくなります。
    1. **Azure Data Lake Storage** **Gen2 参照データ:** Azure Data Lake Storage Gen2 をクエリの参照データとして使用できるようになりました。参照データは静的であるか、時間の経過とともにゆっくりと変化します。これは通常、受信ストリーミングを充実させ、ジョブでルックアップを行うために使用されます。
    1. **メトリック:** コード エディター内でメトリックを表示することで、ジョブの正常性を監視できるようになりました。表示されるメトリックは、既定で過去 1 時間のメトリックです。過去 1 時間から 30 時間の範囲の任意の時間を選択して、ジョブのメトリックを表示できます。
    1. **ジョブの保存:**ジョブの作成中にいつでもジョブを保存できるようになりました。ジョブを開始するには、ジョブのイベント ハブ、変換、およびストリーミング出力を構成する必要があります。
  * **注**: コード エディターなしのプレビュー期間中は、Azure Stream Analytics サービスは一般公開されています。
  * 追加情報: [Azure Stream Analytics を使用したコード ストリーム処理は行わな|Microsoft Docs](https://docs.microsoft.com/en-us/azure/stream-analytics/no-code-stream-processing) 
  
![](https://azurecomcdn.azureedge.net/mediahandler/acomblog/updates/UpdatesV2/blog/43da0606-b784-4457-b00e-1bfed58bf219.png)

<br/>

* 参考
  * Public preview: Four new features in no code editor in Event Hubs
    * [https://azure.microsoft.com/ja-jp/updates/public-preview-4-new-features-in-no-code-editor-in-azure-event-hubs/](https://azure.microsoft.com/ja-jp/updates/public-preview-4-new-features-in-no-code-editor-in-azure-event-hubs/)

---

## 一般提供: アラブ首長国連邦北部アベイラビリティーゾーン
* 対象
  * Regions & Datacenters

<br/>

* 内容
  * UAE North のアベイラビリティーゾーンは、物理的に分離された 3 つの一意の場所または 1 つのリージョン内の "ゾーン" で構成され、障害復旧保護のために Azure リージョン間で可用性と非同期レプリケーションが向上します。
  * アベイラビリティーゾーンは、Azure リージョン内に 3 つ以上の一意の物理的な場所を提供することにより、最も要求の厳しいアプリケーションとサービスの高可用性のための追加オプションと、潜在的なハードウェアおよびソフトウェア障害からの信頼性と保護を提供します。
  * [詳細](https://aka.ms/UAEZones)。

<br/>

* 参考
  * Generally available: UAE North Availability Zones
    * [https://azure.microsoft.com/ja-jp/updates/generally-available-uae-north-availability-zones/](https://azure.microsoft.com/ja-jp/updates/generally-available-uae-north-availability-zones/)

---

## 一般提供: Azure Data Explorer は Amazon S3 からのネイティブ インジェストをサポートしています。
* 対象
  * Azure Data Explorer
  * SDK and Tools

<br/>

* 内容
  * Azure データ エクスプローラー (ADX) は、S3 からのデータの取り込みをネイティブにサポートするようになりました。
  * Azure Data Explorer で S3 インジェストをサポートする前は、S3 からデータを取り込むために、複雑な ETL パイプラインまたはオーケストレーターに依存する必要がありました。新機能により、プロセスが簡素化され、費用対効果が高くスケーラブルな方法でS3からデータを取り込むことができます。
  * 詳しくは [起動ブログ](https://aka.ms/adx.s3ingest.blog) をご覧ください。

<br/>

* 参考
  * General availability: Azure Data Explorer supports native ingestion from Amazon S3
    * [https://azure.microsoft.com/ja-jp/updates/general-availability-azure-data-explorer-supports-native-ingestion-from-amazon-s3/](https://azure.microsoft.com/ja-jp/updates/general-availability-azure-data-explorer-supports-native-ingestion-from-amazon-s3/)

---

