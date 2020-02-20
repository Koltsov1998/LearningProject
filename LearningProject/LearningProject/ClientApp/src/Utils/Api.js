export default class Api {
    static async GetAllPublicsAsync() {
        var response = await fetch("api/publics");
        return await response.json()
    }

    static async AddPublicAsync(publicUrl) {
        return await fetch(`api/publics?PublicUrl=${publicUrl}`, {
            method: 'POST'
        });
    }
}