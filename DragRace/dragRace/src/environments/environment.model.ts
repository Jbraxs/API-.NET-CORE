export interface Environment {
    PRODUCTION: boolean;
    ENV_NAME: string;
    API: Api;
}

export class Api {
    URL: string;
    //VERSION: string;
}