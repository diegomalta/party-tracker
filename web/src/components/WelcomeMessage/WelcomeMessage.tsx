import React from "react";

interface WelcomeMessageProps {
    guestName: string
}


const WelcomeMessage = ({ guestName }: WelcomeMessageProps) => {
    return (<div className="prose text-center pt-6">
        <h2>{guestName}, You're invited to Linas's 8th birthday &#127874; party! &#127881;&#127881;&#127881;</h2>
    </div>)
}

export default WelcomeMessage;