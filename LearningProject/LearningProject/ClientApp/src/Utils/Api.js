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

    static async RemovePublic(publicUrl){
        return await fetch('api/publics', {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
            body: `"${publicUrl}"`
        }
        )
    }
}